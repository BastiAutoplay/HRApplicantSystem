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
    public partial class InterviewEvaluationForm : Form
    {
        private int _userID;
        private int _selectedInterviewID = -1;
        private int _selectedApplicationID = -1;
        private string _selectedApplicantName = "";
        public InterviewEvaluationForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void lblRemarks_Click(object sender, EventArgs e)
        {

        }

        private void InterviewEvaluationForm_Load(object sender, EventArgs e)
        {
            cmbResult.SelectedIndex = 0;
            LoadInterviews("");
        }

        private void LoadInterviews(string searchTerm)
        {
            lvInterviews.Items.Clear();

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT i.InterviewID, i.ApplicationID, " +
                               "ap.FirstName, ap.LastName, " +
                               "i.ScheduledDate, i.Status " +
                               "FROM InterviewSchedules i " +
                               "JOIN Applications a ON i.ApplicationID = a.ApplicationID " +
                               "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                               "WHERE i.Status = 'Scheduled' " +
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
                        reader["InterviewID"].ToString());
                    item.SubItems.Add(fullName);
                    item.SubItems.Add(Convert.ToDateTime(
                        reader["ScheduledDate"]).ToString("MMM dd, yyyy hh:mm tt"));
                    item.SubItems.Add(reader["Status"].ToString());
                    item.Tag = reader["ApplicationID"].ToString() + "," + fullName;

                    lvInterviews.Items.Add(item);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading interviews: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvInterviews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvInterviews.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvInterviews.SelectedItems[0];
                _selectedInterviewID = Convert.ToInt32(selected.Text);

                string[] tag = selected.Tag.ToString().Split(',');
                _selectedApplicationID = Convert.ToInt32(tag[0]);
                _selectedApplicantName = tag[1];

                lblApplicantValue.Text = _selectedApplicantName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInterviews(txtSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedInterviewID == -1)
            {
                MessageBox.Show("Please select an interview first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rtbRemarks.Text.Trim() == "")
            {
                MessageBox.Show("Please add remarks.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Save evaluation
                string evalQuery = "INSERT INTO InterviewEvaluations " +
                                   "(InterviewID, Score, Remarks, Result) " +
                                   "VALUES (@interviewID, @score, @remarks, @result)";
                MySqlCommand evalCmd = new MySqlCommand(evalQuery, conn);
                evalCmd.Parameters.AddWithValue("@interviewID", _selectedInterviewID);
                evalCmd.Parameters.AddWithValue("@score", nudScore.Value);
                evalCmd.Parameters.AddWithValue("@remarks", rtbRemarks.Text.Trim());
                evalCmd.Parameters.AddWithValue("@result", cmbResult.Text);
                evalCmd.ExecuteNonQuery();

                // Update interview status to Completed
                string updateQuery = "UPDATE InterviewSchedules SET Status='Completed' " +
                                     "WHERE InterviewID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@id", _selectedInterviewID);
                updateCmd.ExecuteNonQuery();

                // Update application status
                string newStatus = cmbResult.Text == "Pass" ?
                                   "For Final Review" : "For Interview";

                string appQuery = "UPDATE Applications SET Status=@status, " +
                                  "LastUpdated=NOW() " +
                                  "WHERE ApplicationID=@id";
                MySqlCommand appCmd = new MySqlCommand(appQuery, conn);
                appCmd.Parameters.AddWithValue("@status", newStatus);
                appCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                appCmd.ExecuteNonQuery();

                // Record in history
                string histQuery = "INSERT INTO ApplicationStatusHistory " +
                                   "(ApplicationID, Status, ChangedBy, Remarks) " +
                                   "VALUES (@id, @status, 'HR Staff', @remarks)";
                MySqlCommand histCmd = new MySqlCommand(histQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                histCmd.Parameters.AddWithValue("@status", newStatus);
                histCmd.Parameters.AddWithValue("@remarks",
                    "Interview evaluated. Result: " + cmbResult.Text +
                    ". Score: " + nudScore.Value);
                histCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Evaluation saved successfully!",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Reset
                _selectedInterviewID = -1;
                _selectedApplicationID = -1;
                lblApplicantValue.Text = "-";
                rtbRemarks.Clear();
                nudScore.Value = 0;
                LoadInterviews("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving evaluation: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
