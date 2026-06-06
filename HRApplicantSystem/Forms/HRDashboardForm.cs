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
    public partial class HRDashboardForm : Form
    {
        private int _userID;
        private int _roleID;
        private string _fullName;
        public HRDashboardForm(int userID, int roleID, string fullName)
        {
            InitializeComponent();
            _userID = userID;
            _roleID = roleID;
            _fullName = fullName;
        }

        private void HRDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + _fullName + "!";

            // Show role name
            string[] roles = { "", "Admin", "HR Manager", "HR Staff" };
            if (_roleID <= 3)
                lblRole.Text = "Role: " + roles[_roleID];

            LoadSummary();
        }

        private void LoadSummary()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Total applicants
                string totalQuery = "SELECT COUNT(*) FROM Applications";
                MySqlCommand totalCmd = new MySqlCommand(totalQuery, conn);
                lblTotalValue.Text = totalCmd.ExecuteScalar().ToString();

                // Pending review
                string pendingQuery = "SELECT COUNT(*) FROM Applications " +
                                      "WHERE Status='Submitted'";
                MySqlCommand pendingCmd = new MySqlCommand(pendingQuery, conn);
                lblPendingValue.Text = pendingCmd.ExecuteScalar().ToString();

                // Shortlisted
                string shortlistQuery = "SELECT COUNT(*) FROM Applications " +
                                        "WHERE Status='Shortlisted'";
                MySqlCommand shortlistCmd = new MySqlCommand(shortlistQuery, conn);
                lblShortlistedValue.Text = shortlistCmd.ExecuteScalar().ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplicantList_Click(object sender, EventArgs e)
        {
            HRApplicantListForm listForm = new HRApplicantListForm();
            listForm.ShowDialog();
            LoadSummary();
        }

        private void btnJobVacancies_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Job Vacancy Management - Coming Soon!", "Info");
        }

        private void btnScreening_Click(object sender, EventArgs e)
        {
            ScreeningForm screenForm = new ScreeningForm(_userID);
            screenForm.ShowDialog();
            LoadSummary();
        }

        private void btnInterviewSched_Click(object sender, EventArgs e)
        {
            InterviewSchedulingForm schedForm = new InterviewSchedulingForm(_userID);
            schedForm.ShowDialog();
            LoadSummary();
        }

        private void btnInterviewEval_Click(object sender, EventArgs e)
        {
            InterviewEvaluationForm evalForm = new InterviewEvaluationForm(_userID);
            evalForm.ShowDialog();
            LoadSummary();
        }

        private void btnHiringDecision_Click(object sender, EventArgs e)
        {
            HiringDecisionForm decisionForm = new HiringDecisionForm(_userID, _roleID);
            decisionForm.ShowDialog();
            LoadSummary();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
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
    }
}
