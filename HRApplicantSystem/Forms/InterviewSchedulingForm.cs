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
    public partial class InterviewSchedulingForm : Form
    {
        private int _userID;
        private int _selectedApplicationID = -1;
        private string _selectedApplicantName = "";
        public InterviewSchedulingForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void InterviewSchedulingForm_Load(object sender, EventArgs e)
        {
            cmbMode.SelectedIndex = 0;
            dtpSchedule.Value = DateTime.Now.AddDays(1);
            LoadApplicants("");
            LoadInterviewers();
        }

        private void LoadApplicants(string searchTerm)
        {
            lvApplicants.Items.Clear();

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                               "j.JobTitle, a.Status " +
                               "FROM Applications a " +
                               "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                               "JOIN JobVacancies j ON a.JobID = j.JobID " +
                               "WHERE a.Status = 'Shortlisted' " +
                               "AND (ap.FirstName LIKE @search " +
                               "OR ap.LastName LIKE @search)";

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
                    item.SubItems.Add(reader["Status"].ToString());
                    item.Tag = fullName;

                    lvApplicants.Items.Add(item);
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

        private void LoadInterviewers()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT UserID, FullName FROM Users WHERE IsActive=1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                cmbInterviewer.Items.Clear();
                while (reader.Read())
                {
                    cmbInterviewer.Items.Add(
                        reader["UserID"].ToString() + " - " +
                        reader["FullName"].ToString());
                }

                reader.Close();
                conn.Close();

                if (cmbInterviewer.Items.Count > 0)
                    cmbInterviewer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading interviewers: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvApplicants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApplicants.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvApplicants.SelectedItems[0];
                _selectedApplicationID = Convert.ToInt32(selected.Text);
                _selectedApplicantName = selected.Tag.ToString();
                lblApplicantValue.Text = _selectedApplicantName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadApplicants(txtSearch.Text.Trim());
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            if (_selectedApplicationID == -1)
            {
                MessageBox.Show("Please select an applicant first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtLocation.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a location or link.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate date is not in the past
            if (dtpSchedule.Value <= DateTime.Now)
            {
                MessageBox.Show("Interview date must be in the future.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected interviewer ID
            string interviewerText = cmbInterviewer.Text;
            int interviewerID = Convert.ToInt32(interviewerText.Split('-')[0].Trim());

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Save interview schedule
                string schedQuery = "INSERT INTO InterviewSchedules " +
                                    "(ApplicationID, InterviewerID, ScheduledDate, " +
                                    "Mode, Location, Status) " +
                                    "VALUES (@appID, @interviewerID, @date, " +
                                    "@mode, @location, 'Scheduled')";
                MySqlCommand schedCmd = new MySqlCommand(schedQuery, conn);
                schedCmd.Parameters.AddWithValue("@appID", _selectedApplicationID);
                schedCmd.Parameters.AddWithValue("@interviewerID", interviewerID);
                schedCmd.Parameters.AddWithValue("@date", dtpSchedule.Value);
                schedCmd.Parameters.AddWithValue("@mode", cmbMode.Text);
                schedCmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim());
                schedCmd.ExecuteNonQuery();

                // Update application status
                string updateQuery = "UPDATE Applications SET Status='For Interview', " +
                                     "LastUpdated=NOW() WHERE ApplicationID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                updateCmd.ExecuteNonQuery();

                // Record in history
                string histQuery = "INSERT INTO ApplicationStatusHistory " +
                                   "(ApplicationID, Status, ChangedBy, Remarks) " +
                                   "VALUES (@id, 'For Interview', 'HR Staff', @remarks)";
                MySqlCommand histCmd = new MySqlCommand(histQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                histCmd.Parameters.AddWithValue("@remarks",
                    "Interview scheduled on " +
                    dtpSchedule.Value.ToString("MMMM dd, yyyy hh:mm tt") +
                    " via " + cmbMode.Text +
                    " at " + txtLocation.Text.Trim());
                histCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Interview scheduled successfully for " +
                                _selectedApplicantName + "!",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Reset
                _selectedApplicationID = -1;
                lblApplicantValue.Text = "-";
                txtLocation.Clear();
                LoadApplicants("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error scheduling interview: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
