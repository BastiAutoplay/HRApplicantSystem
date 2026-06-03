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
    public partial class MyDocumentsForm : Form
    {
        private int _applicantID;
        private int _applicationID = -1;
        private int _selectedRequirementTypeID = -1;
        private int _selectedDocumentID = -1;
        public MyDocumentsForm(int applicantID)
        {
            InitializeComponent();
            _applicantID = applicantID;
        }

        private void MyDocumentsForm_Load(object sender, EventArgs e)
        {
            GetApplicationID();
            LoadDocuments();
        }

        private void GetApplicationID()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT ApplicationID FROM Applications " +
                               "WHERE ApplicantID=@id " +
                               "ORDER BY AppliedAt DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _applicantID);
                object result = cmd.ExecuteScalar();

                if (result != null)
                    _applicationID = Convert.ToInt32(result);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDocuments()
        {
            lvDocuments.Items.Clear();

            if (_applicationID == -1)
            {
                MessageBox.Show("No application found. Please apply for a job first.",
                                "Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Get all requirement types
                string reqQuery = "SELECT rt.RequirementTypeID, rt.RequirementName, " +
                                  "ad.DocumentID, ad.FileName, ad.Status, ad.UploadedAt " +
                                  "FROM RequirementTypes rt " +
                                  "LEFT JOIN ApplicantDocuments ad " +
                                  "ON rt.RequirementTypeID = ad.RequirementTypeID " +
                                  "AND ad.ApplicationID = @appID";

                MySqlCommand cmd = new MySqlCommand(reqQuery, conn);
                cmd.Parameters.AddWithValue("@appID", _applicationID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string status = reader["Status"] == DBNull.Value ?
                                   "Missing" : reader["Status"].ToString();
                    string fileName = reader["FileName"] == DBNull.Value ?
                                     "-" : reader["FileName"].ToString();
                    string uploadedAt = reader["UploadedAt"] == DBNull.Value ?
                                       "-" : Convert.ToDateTime(
                                       reader["UploadedAt"]).ToString("MMM dd, yyyy");

                    ListViewItem item = new ListViewItem(
                        reader["RequirementName"].ToString());
                    item.SubItems.Add(fileName);
                    item.SubItems.Add(status);
                    item.SubItems.Add(uploadedAt);
                    item.Tag = reader["RequirementTypeID"].ToString() + "," +
                               (reader["DocumentID"] == DBNull.Value ?
                               "-1" : reader["DocumentID"].ToString());

                    // Color code missing vs submitted
                    item.ForeColor = status == "Missing" ?
                        System.Drawing.Color.Red :
                        System.Drawing.Color.Green;

                    lvDocuments.Items.Add(item);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading documents: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDocuments.SelectedItems.Count > 0)
            {
                ListViewItem selected = lvDocuments.SelectedItems[0];
                lblSelectedValue.Text = selected.Text;

                string[] tag = selected.Tag.ToString().Split(',');
                _selectedRequirementTypeID = Convert.ToInt32(tag[0]);
                _selectedDocumentID = Convert.ToInt32(tag[1]);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (_selectedRequirementTypeID == -1)
            {
                MessageBox.Show("Please select a document type first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF Files|*.pdf|Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
            dialog.Title = "Select Document";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(dialog.FileName);
                string filePath = dialog.FileName;

                try
                {
                    MySqlConnection conn = DBConnection.GetConnection();
                    conn.Open();

                    if (_selectedDocumentID == -1)
                    {
                        // Insert new document
                        string insertQuery = "INSERT INTO ApplicantDocuments " +
                                             "(ApplicationID, RequirementTypeID, " +
                                             "FileName, FilePath, Status, UploadedAt) " +
                                             "VALUES (@appID, @reqID, @fileName, " +
                                             "@filePath, 'Submitted', NOW())";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@appID", _applicationID);
                        insertCmd.Parameters.AddWithValue("@reqID",
                            _selectedRequirementTypeID);
                        insertCmd.Parameters.AddWithValue("@fileName", fileName);
                        insertCmd.Parameters.AddWithValue("@filePath", filePath);
                        insertCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Update existing document
                        string updateQuery = "UPDATE ApplicantDocuments SET " +
                                             "FileName=@fileName, FilePath=@filePath, " +
                                             "Status='Submitted', UploadedAt=NOW() " +
                                             "WHERE DocumentID=@docID";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@fileName", fileName);
                        updateCmd.Parameters.AddWithValue("@filePath", filePath);
                        updateCmd.Parameters.AddWithValue("@docID", _selectedDocumentID);
                        updateCmd.ExecuteNonQuery();
                    }

                    conn.Close();

                    MessageBox.Show("Document uploaded successfully!",
                                    "Success", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    LoadDocuments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
