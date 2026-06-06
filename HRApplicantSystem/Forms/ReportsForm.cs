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
using System.IO;

namespace HRApplicantSystem.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = 0;
        }

        private void SetupColumns(List<string> columns)
        {
            lvReport.Columns.Clear();
            lvReport.Items.Clear();
            foreach (string col in columns)
                lvReport.Columns.Add(col, 150);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string selected = cmbReportType.Text;

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "";

                switch (selected)
                {
                    case "All Applicants":
                        SetupColumns(new List<string> {
                    "App ID", "Name", "Position", "Date Applied", "Status" });
                        query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                                "j.JobTitle, a.AppliedAt, a.Status " +
                                "FROM Applications a " +
                                "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                                "JOIN JobVacancies j ON a.JobID = j.JobID " +
                                "ORDER BY a.AppliedAt DESC";
                        break;

                    case "Pending Applications":
                        SetupColumns(new List<string> {
                    "App ID", "Name", "Position", "Date Applied" });
                        query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                                "j.JobTitle, a.AppliedAt " +
                                "FROM Applications a " +
                                "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                                "JOIN JobVacancies j ON a.JobID = j.JobID " +
                                "WHERE a.Status = 'Submitted' " +
                                "ORDER BY a.AppliedAt DESC";
                        break;

                    case "Shortlisted Applicants":
                        SetupColumns(new List<string> {
                    "App ID", "Name", "Position", "Status" });
                        query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                                "j.JobTitle, a.Status " +
                                "FROM Applications a " +
                                "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                                "JOIN JobVacancies j ON a.JobID = j.JobID " +
                                "WHERE a.Status = 'Shortlisted'";
                        break;

                    case "Accepted Applicants":
                        SetupColumns(new List<string> {
                    "App ID", "Name", "Position", "Decision" });
                        query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                                "j.JobTitle, hd.Decision " +
                                "FROM HiringDecisions hd " +
                                "JOIN Applications a ON hd.ApplicationID = a.ApplicationID " +
                                "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                                "JOIN JobVacancies j ON a.JobID = j.JobID " +
                                "WHERE hd.Decision = 'Accepted'";
                        break;

                    case "Rejected Applicants":
                        SetupColumns(new List<string> {
                    "App ID", "Name", "Position", "Decision" });
                        query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                                "j.JobTitle, hd.Decision " +
                                "FROM HiringDecisions hd " +
                                "JOIN Applications a ON hd.ApplicationID = a.ApplicationID " +
                                "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                                "JOIN JobVacancies j ON a.JobID = j.JobID " +
                                "WHERE hd.Decision = 'Rejected'";
                        break;

                    case "Missing Documents":
                        SetupColumns(new List<string> {
                    "App ID", "Name", "Missing Requirement" });
                        query = "SELECT a.ApplicationID, ap.FirstName, ap.LastName, " +
                                "rt.RequirementName " +
                                "FROM Applications a " +
                                "JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID " +
                                "JOIN RequirementTypes rt ON 1=1 " +
                                "WHERE NOT EXISTS (" +
                                "SELECT 1 FROM ApplicantDocuments ad " +
                                "WHERE ad.ApplicationID = a.ApplicationID " +
                                "AND ad.RequirementTypeID = rt.RequirementTypeID " +
                                "AND ad.Status = 'Submitted') " +
                                "ORDER BY a.ApplicationID";
                        break;
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader[0].ToString());
                    for (int i = 1; i < reader.FieldCount; i++)
                    {
                        if (reader[i] is DateTime)
                            item.SubItems.Add(
                                Convert.ToDateTime(reader[i]).ToString("MMM dd, yyyy"));
                        else
                            item.SubItems.Add(reader[i].ToString());
                    }
                    lvReport.Items.Add(item);
                }

                reader.Close();
                conn.Close();

                MessageBox.Show("Report generated! " + lvReport.Items.Count +
                                " records found.", "Done",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lvReport.Items.Count == 0)
            {
                MessageBox.Show("Please generate a report first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV Files|*.csv";
            saveDialog.FileName = cmbReportType.Text.Replace(" ", "_") + "_Report";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                // Headers
                List<string> headers = new List<string>();
                foreach (ColumnHeader col in lvReport.Columns)
                    headers.Add(col.Text);
                sb.AppendLine(string.Join(",", headers));

                // Rows
                foreach (ListViewItem item in lvReport.Items)
                {
                    List<string> row = new List<string>();
                    row.Add(item.Text);
                    foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                    {
                        if (sub.Text != item.Text)
                            row.Add(sub.Text);
                    }
                    sb.AppendLine(string.Join(",", row));
                }

                File.WriteAllText(saveDialog.FileName, sb.ToString());

                MessageBox.Show("Report exported successfully!",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
