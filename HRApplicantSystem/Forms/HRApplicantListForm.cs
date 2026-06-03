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
    public partial class HRApplicantListForm : Form
    {
        private int _selectedApplicationID = -1;
        public HRApplicantListForm()
        {
            InitializeComponent();
        }

        private void HRApplicantListForm_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            LoadApplicants("", "All");
        }

        private void LoadApplicants(string searchTerm, string statusFilter)
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
                               "WHERE (ap.FirstName LIKE @search " +
                               "OR ap.LastName LIKE @search " +
                               "OR j.JobTitle LIKE @search)";

                if (statusFilter != "All")
                    query += " AND a.Status=@status";

                query += " ORDER BY a.AppliedAt DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                if (statusFilter != "All")
                    cmd.Parameters.AddWithValue("@status", statusFilter);

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

                    // Color code by status
                    switch (reader["Status"].ToString())
                    {
                        case "Accepted":
                            item.ForeColor = System.Drawing.Color.Green;
                            break;
                        case "Rejected":
                            item.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "Submitted":
                            item.ForeColor = System.Drawing.Color.SteelBlue;
                            break;
                    }

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
                _selectedApplicationID = Convert.ToInt32(
                    lvApplicants.SelectedItems[0].Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadApplicants(txtSearch.Text.Trim(), cmbFilter.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilter.SelectedIndex = 0;
            LoadApplicants("", "All");
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            if (_selectedApplicationID == -1)
            {
                MessageBox.Show("Please select an applicant first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HRApplicantReviewForm reviewForm = new HRApplicantReviewForm(
                _selectedApplicationID);
            reviewForm.ShowDialog();
            LoadApplicants("", "All");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
