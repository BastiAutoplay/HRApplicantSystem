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
    public partial class ApplicationStatusForm : Form
    {
        private int _applicantID;
        private int _applicationID = -1;
        public ApplicationStatusForm(int applicantID)
        {
            InitializeComponent();
            _applicantID = applicantID;
        }

        private void ApplicationStatusForm_Load(object sender, EventArgs e)
        {
            LoadStatus();
        }

        private void LoadStatus()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Get latest application
                string appQuery = "SELECT a.ApplicationID, a.Status, j.JobTitle " +
                                  "FROM Applications a " +
                                  "JOIN JobVacancies j ON a.JobID = j.JobID " +
                                  "WHERE a.ApplicantID=@id " +
                                  "ORDER BY a.AppliedAt DESC LIMIT 1";

                MySqlCommand appCmd = new MySqlCommand(appQuery, conn);
                appCmd.Parameters.AddWithValue("@id", _applicantID);
                MySqlDataReader appReader = appCmd.ExecuteReader();

                if (appReader.Read())
                {
                    _applicationID = Convert.ToInt32(appReader["ApplicationID"]);
                    string status = appReader["Status"].ToString();

                    lblJobValue.Text = appReader["JobTitle"].ToString();
                    lblCurrentValue.Text = status;

                    // Color code current status
                    switch (status)
                    {
                        case "Accepted":
                            lblCurrentValue.ForeColor = System.Drawing.Color.Green;
                            break;
                        case "Rejected":
                            lblCurrentValue.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "Shortlisted":
                        case "For Interview":
                            lblCurrentValue.ForeColor = System.Drawing.Color.SteelBlue;
                            break;
                        default:
                            lblCurrentValue.ForeColor = System.Drawing.Color.Orange;
                            break;
                    }
                }
                else
                {
                    lblJobValue.Text = "No application found";
                    appReader.Close();
                    conn.Close();
                    return;
                }

                appReader.Close();

                // Get interview schedule if any
                string interviewQuery = "SELECT ScheduledDate, Mode, Location " +
                                        "FROM InterviewSchedules " +
                                        "WHERE ApplicationID=@id " +
                                        "AND Status='Scheduled' LIMIT 1";

                MySqlCommand intCmd = new MySqlCommand(interviewQuery, conn);
                intCmd.Parameters.AddWithValue("@id", _applicationID);
                MySqlDataReader intReader = intCmd.ExecuteReader();

                if (intReader.Read())
                {
                    string schedule = Convert.ToDateTime(
                        intReader["ScheduledDate"]).ToString("MMMM dd, yyyy hh:mm tt");
                    string mode = intReader["Mode"].ToString();
                    string location = intReader["Location"].ToString();

                    lblInterviewValue.Text = schedule + " | " + mode +
                                             " | " + location;
                    lblInterviewValue.ForeColor = System.Drawing.Color.SteelBlue;
                }

                intReader.Close();

                // Load timeline
                lvTimeline.Items.Clear();

                string historyQuery = "SELECT ChangedAt, Status, Remarks " +
                                      "FROM ApplicationStatusHistory " +
                                      "WHERE ApplicationID=@id " +
                                      "ORDER BY ChangedAt ASC";

                MySqlCommand histCmd = new MySqlCommand(historyQuery, conn);
                histCmd.Parameters.AddWithValue("@id", _applicationID);
                MySqlDataReader histReader = histCmd.ExecuteReader();

                while (histReader.Read())
                {
                    ListViewItem item = new ListViewItem(
                        Convert.ToDateTime(histReader["ChangedAt"])
                        .ToString("MMM dd, yyyy hh:mm tt"));
                    item.SubItems.Add(histReader["Status"].ToString());
                    item.SubItems.Add(histReader["Remarks"].ToString());

                    // Color code each status in timeline
                    switch (histReader["Status"].ToString())
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

                    lvTimeline.Items.Add(item);
                }

                histReader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading status: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
