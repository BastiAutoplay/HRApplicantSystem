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
    public partial class JobVacanciesForm : Form
    {
        private int _applicantAccountID;
        private int _applicantID;
        private int _selectedJobID = -1;
        public JobVacanciesForm(int applicantAccountID, int applicantID)
        {
            InitializeComponent();
            _applicantAccountID = applicantAccountID;
            _applicantID = applicantID;
        }

        private void JobVacanciesForm_Load(object sender, EventArgs e)
        {
            LoadJobs("");
        }

        private void LoadJobs(string searchTerm)
        {
            lvJobs.Items.Clear();

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT j.JobID, j.JobTitle, d.DepartmentName, " +
                               "j.EmploymentType, j.Status, j.Description, " +
                               "j.Qualifications FROM JobVacancies j " +
                               "LEFT JOIN Departments d ON j.DepartmentID = d.DepartmentID " +
                               "WHERE j.Status = 'Open' AND " +
                               "(j.JobTitle LIKE @search OR d.DepartmentName LIKE @search)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(
                        reader["JobID"].ToString());
                    item.SubItems.Add(reader["JobTitle"].ToString());
                    item.SubItems.Add(reader["DepartmentName"].ToString());
                    item.SubItems.Add(reader["EmploymentType"].ToString());
                    item.SubItems.Add(reader["Status"].ToString());

                    // Store full details in Tag for display later
                    item.Tag = "Position: " + reader["JobTitle"].ToString() +
                               "\nDepartment: " + reader["DepartmentName"].ToString() +
                               "\nDescription: " + reader["Description"].ToString() +
                               "\nQualifications: " + reader["Qualifications"].ToString();

                    lvJobs.Items.Add(item);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading jobs: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvJobs.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvJobs.SelectedItems[0];
                _selectedJobID = Convert.ToInt32(selected.Text);
                rtbDetails.Text = selected.Tag.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadJobs(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadJobs("");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_selectedJobID == -1)
            {
                MessageBox.Show("Please select a job first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Check for duplicate application
                string checkQuery = "SELECT COUNT(*) FROM Applications " +
                                    "WHERE ApplicantID=@applicantID AND JobID=@jobID";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@applicantID", _applicantID);
                checkCmd.Parameters.AddWithValue("@jobID", _selectedJobID);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    MessageBox.Show("You already applied for this job!", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }

                // Create application
                string insertQuery = "INSERT INTO Applications " +
                                     "(ApplicantID, JobID, Status) " +
                                     "VALUES (@applicantID, @jobID, 'Draft')";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@applicantID", _applicantID);
                insertCmd.Parameters.AddWithValue("@jobID", _selectedJobID);
                insertCmd.ExecuteNonQuery();

                int newAppID = Convert.ToInt32(insertCmd.LastInsertedId);

                // Record in status history
                string historyQuery = "INSERT INTO ApplicationStatusHistory " +
                                      "(ApplicationID, Status, ChangedBy, Remarks) " +
                                      "VALUES (@appID, 'Draft', 'Applicant', " +
                                      "'Application created')";
                MySqlCommand histCmd = new MySqlCommand(historyQuery, conn);
                histCmd.Parameters.AddWithValue("@appID", newAppID);
                histCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Application created! Go to My Application to submit it.",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
