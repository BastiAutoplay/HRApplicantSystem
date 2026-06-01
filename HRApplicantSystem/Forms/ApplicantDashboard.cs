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
    public partial class ApplicantDashboard : Form
    {

        private int _applicantAccountID;
        private int _applicantID;
        private string _fullName;

        public ApplicantDashboard(int applicantAccountID)
{
    InitializeComponent();
    _applicantAccountID = applicantAccountID;
}

        private void lblMissingValue_Click(object sender, EventArgs e)
        {

        }

        private void lblInterviewValue_Click(object sender, EventArgs e)
        {

        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Documents - Coming Soon!", "Info");
        }

        private void ApplicantDashboard_Load(object sender, EventArgs e)
        {
            LoadApplicantInfo();
        }

        private void LoadApplicantInfo()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Get applicant name
                string query = "SELECT ApplicantID, FirstName, LastName FROM Applicants " +
                               "WHERE ApplicantAccountID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _applicantAccountID);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _applicantID = Convert.ToInt32(reader["ApplicantID"]);
                    _fullName = reader["FirstName"].ToString() + " " +
                                reader["LastName"].ToString();
                    lblWelcome.Text = "Welcome, " + _fullName + "!";
                }
                reader.Close();

                // Get application status
                string appQuery = "SELECT a.Status, j.JobTitle FROM Applications a " +
                                  "JOIN JobVacancies j ON a.JobID = j.JobID " +
                                  "WHERE a.ApplicantID=@applicantID " +
                                  "ORDER BY a.AppliedAt DESC LIMIT 1";
                MySqlCommand appCmd = new MySqlCommand(appQuery, conn);
                appCmd.Parameters.AddWithValue("@applicantID", _applicantID);
                MySqlDataReader appReader = appCmd.ExecuteReader();

                if (appReader.Read())
                {
                    string status = appReader["Status"].ToString();
                    string jobTitle = appReader["JobTitle"].ToString();
                    lblStatusValue.Text = status + " - " + jobTitle;

                    // Color code the status
                    switch (status)
                    {
                        case "Accepted":
                            lblStatusValue.ForeColor = System.Drawing.Color.Green;
                            break;
                        case "Rejected":
                            lblStatusValue.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "Under Review":
                        case "Shortlisted":
                            lblStatusValue.ForeColor = System.Drawing.Color.SteelBlue;
                            break;
                        default:
                            lblStatusValue.ForeColor = System.Drawing.Color.Gray;
                            break;
                    }
                }
                appReader.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ApplicantProfileForm profileForm = new ApplicantProfileForm(
                _applicantAccountID, _applicantID);
            profileForm.ShowDialog();
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            JobVacanciesForm jobsForm = new JobVacanciesForm(
                _applicantAccountID, _applicantID);
            jobsForm.ShowDialog();
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Application - Coming Soon!", "Info");
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application Status - Coming Soon!", "Info");
        }
    }
}
