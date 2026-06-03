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
    public partial class HRApplicantReviewForm : Form
    {
        private int _applicationID;
        private string _currentStatus = "";
        public HRApplicantReviewForm(int applicationID)
        {
            InitializeComponent();
            _applicationID = applicationID;
        }

        private void HRApplicantReviewForm_Load(object sender, EventArgs e)
        {
            LoadApplicantDetails();
        }

        private void LoadApplicantDetails()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT ap.FirstName, ap.LastName, ap.Phone, " +
                               "ap.Address, j.JobTitle, a.Status " +
                               "FROM Applications a " +
                               "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                               "JOIN JobVacancies j ON a.JobID = j.JobID " +
                               "WHERE a.ApplicationID=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _applicationID);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _currentStatus = reader["Status"].ToString();
                    lblNameValue.Text = reader["FirstName"].ToString() + " " +
                                        reader["LastName"].ToString();
                    lblJobValue.Text = reader["JobTitle"].ToString();
                    lblStatusValue.Text = _currentStatus;
                    lblContactValue.Text = reader["Phone"].ToString();
                    lblAddressValue.Text = reader["Address"].ToString();

                    // Enable/disable buttons based on status
                    btnStartReview.Enabled = _currentStatus == "Submitted";
                    btnShortlist.Enabled = _currentStatus == "Under Review";
                    btnReject.Enabled = _currentStatus == "Under Review" ||
                                        _currentStatus == "Submitted";
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus(string newStatus, string remarks)
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string updateQuery = "UPDATE Applications SET Status=@status, " +
                                     "LastUpdated=NOW() WHERE ApplicationID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@status", newStatus);
                updateCmd.Parameters.AddWithValue("@id", _applicationID);
                updateCmd.ExecuteNonQuery();

                string historyQuery = "INSERT INTO ApplicationStatusHistory " +
                                      "(ApplicationID, Status, ChangedBy, Remarks) " +
                                      "VALUES (@id, @status, 'HR Staff', @remarks)";
                MySqlCommand histCmd = new MySqlCommand(historyQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _applicationID);
                histCmd.Parameters.AddWithValue("@status", newStatus);
                histCmd.Parameters.AddWithValue("@remarks", remarks);
                histCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Status updated to: " + newStatus,
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadApplicantDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartReview_Click(object sender, EventArgs e)
        {
            UpdateStatus("Under Review", "HR started reviewing the application.");
        }

        private void btnShortlist_Click(object sender, EventArgs e)
        {
            string remarks = rtbRemarks.Text.Trim();
            if (remarks == "")
            {
                MessageBox.Show("Please add remarks before shortlisting.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateStatus("Shortlisted", remarks);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            string remarks = rtbRemarks.Text.Trim();
            if (remarks == "")
            {
                MessageBox.Show("Please add remarks before rejecting.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to reject this applicant?",
                "Confirm Reject", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
                UpdateStatus("Rejected", remarks);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }
    }
}
