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
    public partial class JobVacancyManagementForm : Form
    {
        private int _selectedJobID = -1;
        public JobVacancyManagementForm()
        {
            InitializeComponent();
        }

        private void JobVacancyManagementForm_Load(object sender, EventArgs e)
        {
            cmbEmployment.SelectedIndex = 0;
            LoadDepartments();
            LoadJobs();
        }

        private void LoadDepartments()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT DepartmentID, DepartmentName FROM Departments";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                cmbDepartment.Items.Clear();
                while (reader.Read())
                {
                    cmbDepartment.Items.Add(
                        reader["DepartmentID"].ToString() + " - " +
                        reader["DepartmentName"].ToString());
                }

                reader.Close();
                conn.Close();

                if (cmbDepartment.Items.Count > 0)
                    cmbDepartment.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJobs()
        {
            lvJobs.Items.Clear();

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT j.JobID, j.JobTitle, d.DepartmentName, " +
                               "j.EmploymentType, j.Status " +
                               "FROM JobVacancies j " +
                               "LEFT JOIN Departments d ON j.DepartmentID = d.DepartmentID " +
                               "ORDER BY j.CreatedAt DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(
                        reader["JobID"].ToString());
                    item.SubItems.Add(reader["JobTitle"].ToString());
                    item.SubItems.Add(reader["DepartmentName"].ToString());
                    item.SubItems.Add(reader["EmploymentType"].ToString());
                    item.SubItems.Add(reader["Status"].ToString());

                    // Color code open vs closed
                    item.ForeColor = reader["Status"].ToString() == "Open" ?
                        System.Drawing.Color.Green :
                        System.Drawing.Color.Red;

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
                _selectedJobID = Convert.ToInt32(
                    lvJobs.SelectedItems[0].Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtJobTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a job title.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rtbDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a job description.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get department ID from selection
                int deptID = Convert.ToInt32(
                    cmbDepartment.Text.Split('-')[0].Trim());

                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "INSERT INTO JobVacancies " +
                               "(DepartmentID, JobTitle, Description, " +
                               "Qualifications, EmploymentType, Status) " +
                               "VALUES (@deptID, @title, @desc, @qual, @type, 'Open')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@deptID", deptID);
                cmd.Parameters.AddWithValue("@title", txtJobTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", rtbDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@qual", rtbQualifications.Text.Trim());
                cmd.Parameters.AddWithValue("@type", cmbEmployment.Text);
                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Job vacancy added successfully!",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Reset fields
                txtJobTitle.Clear();
                rtbDescription.Clear();
                rtbQualifications.Clear();
                LoadJobs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding job: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateJobStatus(string status)
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

                string query = "UPDATE JobVacancies SET Status=@status " +
                               "WHERE JobID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", _selectedJobID);
                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Job status updated to " + status + "!",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LoadJobs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating job: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UpdateJobStatus("Closed");
        }

        private void btnReopen_Click(object sender, EventArgs e)
        {
            UpdateJobStatus("Open");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
