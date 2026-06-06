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
    public partial class ScreeningForm : Form
    {
        private int _userID;
        private int _selectedApplicationID = -1;
        public ScreeningForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void lblApplicant_Click(object sender, EventArgs e)
        {

        }

        private void lblApplicantValue_Click(object sender, EventArgs e)
        {

        }

        private void ScreeningForm_Load(object sender, EventArgs e)
        {
            LoadApplicants("");
        }

        private void LoadApplicants(string searchTerm)
        {
            lvApplicants.Items.Clear();

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                               "j.JobTitle, a.AppliedAt, a.Status " +
                               "FROM Applications a " +
                               "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                               "JOIN JobVacancies j ON a.JobID = j.JobID " +
                               "WHERE a.Status = 'Under Review' " +
                               "AND (ap.FirstName LIKE @search " +
                               "OR ap.LastName LIKE @search " +
                               "OR j.JobTitle LIKE @search)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string fullName = reader["FirstName"].ToString() + " " +
                                      reader["LastName"].ToString();

                    ListViewItem item = new ListViewItem(
                        reader["ApplicationID"].ToString());
                    item.SubItems.Add(fullName);
                    item.SubItems.Add(reader["JobTitle"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(
                        reader["AppliedAt"]).ToString("MMM dd, yyyy"));
                    item.SubItems.Add(reader["Status"].ToString());
                    item.Tag = fullName + "," + reader["JobTitle"].ToString();

                    lvApplicants.Items.Add(item);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicants: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvApplicants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApplicants.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvApplicants.SelectedItems[0];
                _selectedApplicationID = Convert.ToInt32(selected.Text);

                string[] tag = selected.Tag.ToString().Split(',');
                lblApplicantValue.Text = tag[0];
                lblPositionValue.Text = tag[1];
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadApplicants(txtSearch.Text.Trim());
        }

        private void ScreenApplicant(string result, string newStatus)
        {
            if (_selectedApplicationID == -1)
            {
                MessageBox.Show("Please select an applicant first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rtbRemarks.Text.Trim() == "")
            {
                MessageBox.Show("Please add screening remarks.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Save screening result
                string screenQuery = "INSERT INTO ScreeningResults " +
                                     "(ApplicationID, ScreenedBy, Result, Remarks) " +
                                     "VALUES (@appID, @userID, @result, @remarks)";
                MySqlCommand screenCmd = new MySqlCommand(screenQuery, conn);
                screenCmd.Parameters.AddWithValue("@appID", _selectedApplicationID);
                screenCmd.Parameters.AddWithValue("@userID", _userID);
                screenCmd.Parameters.AddWithValue("@result", result);
                screenCmd.Parameters.AddWithValue("@remarks", rtbRemarks.Text.Trim());
                screenCmd.ExecuteNonQuery();

                // Update application status
                string updateQuery = "UPDATE Applications SET Status=@status, " +
                                     "LastUpdated=NOW() WHERE ApplicationID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@status", newStatus);
                updateCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                updateCmd.ExecuteNonQuery();

                // Record in history
                string histQuery = "INSERT INTO ApplicationStatusHistory " +
                                   "(ApplicationID, Status, ChangedBy, Remarks) " +
                                   "VALUES (@id, @status, 'HR Staff', @remarks)";
                MySqlCommand histCmd = new MySqlCommand(histQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                histCmd.Parameters.AddWithValue("@status", newStatus);
                histCmd.Parameters.AddWithValue("@remarks",
                    "Screening result: " + result + ". " + rtbRemarks.Text.Trim());
                histCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Applicant marked as " + result + "!",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Reset
                _selectedApplicationID = -1;
                lblApplicantValue.Text = "-";
                lblPositionValue.Text = "-";
                rtbRemarks.Clear();
                LoadApplicants("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQualified_Click(object sender, EventArgs e)
        {
            ScreenApplicant("Qualified", "Shortlisted");
        }

        private void btnNotQualified_Click(object sender, EventArgs e)
        {
            ScreenApplicant("Not Qualified", "Rejected");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
