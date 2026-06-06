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
    public partial class HiringDecisionForm : Form
    {
        private int _userID;
        private int _roleID;
        private int _selectedApplicationID = -1;
        private string _selectedApplicantName = "";
        private string _selectedPosition = "";
        public HiringDecisionForm(int userID, int roleID)
        {
            InitializeComponent();
            _userID = userID;
            _roleID = roleID;
        }

        private void lblApplicant_Click(object sender, EventArgs e)
        {

        }

        private void lblPosition_Click(object sender, EventArgs e)
        {

        }

        private void HiringDecisionForm_Load(object sender, EventArgs e)
        {
            // Only HR Manager and Admin allowed
            if (_roleID == 3)
            {
                MessageBox.Show("Access Denied. Only HR Manager or Admin " +
                                "can make hiring decisions.", "Access Denied",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

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
                               "j.JobTitle, a.Status " +
                               "FROM Applications a " +
                               "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                               "JOIN JobVacancies j ON a.JobID = j.JobID " +
                               "WHERE a.Status = 'For Final Review' " +
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
                _selectedApplicantName = tag[0];
                _selectedPosition = tag[1];

                lblApplicantValue.Text = _selectedApplicantName;
                lblPositionValue.Text = _selectedPosition;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadApplicants(txtSearch.Text.Trim());
        }

        private void MakeDecision(string decision)
        {
            if (_selectedApplicationID == -1)
            {
                MessageBox.Show("Please select an applicant first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rtbRemarks.Text.Trim() == "")
            {
                MessageBox.Show("Please add remarks before making a decision.",
                                "Warning", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = "Are you sure you want to mark this applicant as " +
                                decision + "?";
            DialogResult confirm = MessageBox.Show(confirmMsg, "Confirm Decision",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Save hiring decision
                string decisionQuery = "INSERT INTO HiringDecisions " +
                                       "(ApplicationID, DecidedBy, Decision, Remarks) " +
                                       "VALUES (@appID, @userID, @decision, @remarks)";
                MySqlCommand decisionCmd = new MySqlCommand(decisionQuery, conn);
                decisionCmd.Parameters.AddWithValue("@appID", _selectedApplicationID);
                decisionCmd.Parameters.AddWithValue("@userID", _userID);
                decisionCmd.Parameters.AddWithValue("@decision", decision);
                decisionCmd.Parameters.AddWithValue("@remarks", rtbRemarks.Text.Trim());
                decisionCmd.ExecuteNonQuery();

                // Update application status
                string updateQuery = "UPDATE Applications SET Status=@status, " +
                                     "LastUpdated=NOW() WHERE ApplicationID=@id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@status", decision);
                updateCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                updateCmd.ExecuteNonQuery();

                // Record in history
                string histQuery = "INSERT INTO ApplicationStatusHistory " +
                                   "(ApplicationID, Status, ChangedBy, Remarks) " +
                                   "VALUES (@id, @status, 'HR Manager', @remarks)";
                MySqlCommand histCmd = new MySqlCommand(histQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _selectedApplicationID);
                histCmd.Parameters.AddWithValue("@status", decision);
                histCmd.Parameters.AddWithValue("@remarks",
                    "Final decision by HR Manager: " + decision +
                    ". " + rtbRemarks.Text.Trim());
                histCmd.ExecuteNonQuery();

                // Record in audit trail
                string auditQuery = "INSERT INTO AuditTrail " +
                                    "(UserType, UserID, Action, AffectedTable, AffectedID) " +
                                    "VALUES ('HR Manager', @userID, @action, " +
                                    "'Applications', @appID)";
                MySqlCommand auditCmd = new MySqlCommand(auditQuery, conn);
                auditCmd.Parameters.AddWithValue("@userID", _userID);
                auditCmd.Parameters.AddWithValue("@action",
                    "Final hiring decision: " + decision +
                    " for ApplicationID " + _selectedApplicationID);
                auditCmd.Parameters.AddWithValue("@appID", _selectedApplicationID);
                auditCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Decision saved! Applicant marked as " + decision + ".",
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
                MessageBox.Show("Error saving decision: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            MakeDecision("Accepted");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            MakeDecision("Rejected");
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            MakeDecision("For Final Review");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
