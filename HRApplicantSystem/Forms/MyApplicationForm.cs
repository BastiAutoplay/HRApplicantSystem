using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;

namespace HRApplicantSystem.Forms
{
    public partial class MyApplicationForm : Form
    {
        private int _applicantID;
        private int _applicationID = -1;
        private string _currentStatus = "";

        public MyApplicationForm(int applicantID)
        {
            InitializeComponent();
            _applicantID = applicantID;
        }

        private void MyApplicationForm_Load(object sender, EventArgs e)
        {
            LoadApplication();
        }

        private void LoadApplication()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT a.ApplicationID, a.Status, a.AppliedAt, " +
                               "j.JobTitle FROM Applications a " +
                               "JOIN JobVacancies j ON a.JobID = j.JobID " +
                               "WHERE a.ApplicantID=@id " +
                               "ORDER BY a.AppliedAt DESC LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _applicantID);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _applicationID = Convert.ToInt32(reader["ApplicationID"]);
                    _currentStatus = reader["Status"].ToString();

                    lblJobValue.Text = reader["JobTitle"].ToString();
                    lblStatusValue.Text = _currentStatus;
                    lblAppliedAtValue.Text = Convert.ToDateTime(
                        reader["AppliedAt"]).ToString("MMMM dd, yyyy");

                    // Color code status
                    switch (_currentStatus)
                    {
                        case "Accepted":
                            lblStatusValue.ForeColor = System.Drawing.Color.Green;
                            break;
                        case "Rejected":
                            lblStatusValue.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "Draft":
                            lblStatusValue.ForeColor = System.Drawing.Color.Orange;
                            break;
                        default:
                            lblStatusValue.ForeColor = System.Drawing.Color.SteelBlue;
                            break;
                    }

                    // Only allow submit/withdraw if still Draft
                    bool isDraft = _currentStatus == "Draft";
                    btnSubmit.Enabled = isDraft;
                    btnWithdraw.Enabled = isDraft;
                }
                else
                {
                    lblJobValue.Text = "No application found";
                    btnSubmit.Enabled = false;
                    btnWithdraw.Enabled = false;
                }

                reader.Close();

                // Load HR remarks if any
                if (_applicationID != -1)
                {
                    string remarksQuery = "SELECT Remarks, ChangedAt FROM " +
                                          "ApplicationStatusHistory " +
                                          "WHERE ApplicationID=@id " +
                                          "ORDER BY ChangedAt DESC LIMIT 1";
                    MySqlCommand remarksCmd = new MySqlCommand(remarksQuery, conn);
                    remarksCmd.Parameters.AddWithValue("@id", _applicationID);
                    MySqlDataReader remarksReader = remarksCmd.ExecuteReader();

                    if (remarksReader.Read())
                        rtbRemarks.Text = remarksReader["Remarks"].ToString();

                    remarksReader.Close();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_applicationID == -1)
            {
                MessageBox.Show("No application found.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to submit your application?",
                "Confirm Submit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Update application status
                string updateQuery = "UPDATE Applications SET Status='Submitted', " +
                                     "LastUpdated=NOW() WHERE ApplicationID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@id", _applicationID);
                updateCmd.ExecuteNonQuery();

                // Record in history
                string historyQuery = "INSERT INTO ApplicationStatusHistory " +
                                      "(ApplicationID, Status, ChangedBy, Remarks) " +
                                      "VALUES (@id, 'Submitted', 'Applicant', " +
                                      "'Application submitted by applicant')";
                MySqlCommand histCmd = new MySqlCommand(historyQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _applicationID);
                histCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Application submitted successfully!",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (_applicationID == -1) return;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to withdraw your application? This cannot be undone.",
                "Confirm Withdraw", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string updateQuery = "UPDATE Applications SET Status='Withdrawn', " +
                                     "LastUpdated=NOW() WHERE ApplicationID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@id", _applicationID);
                updateCmd.ExecuteNonQuery();

                string historyQuery = "INSERT INTO ApplicationStatusHistory " +
                                      "(ApplicationID, Status, ChangedBy, Remarks) " +
                                      "VALUES (@id, 'Withdrawn', 'Applicant', " +
                                      "'Application withdrawn by applicant')";
                MySqlCommand histCmd = new MySqlCommand(historyQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _applicationID);
                histCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Application withdrawn.",
                                "Done", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadApplication();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error withdrawing: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
