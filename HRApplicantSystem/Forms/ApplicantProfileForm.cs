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
    public partial class ApplicantProfileForm : Form
    {
        private int _applicantID;
        private int _applicantAccountID;

        public ApplicantProfileForm(int applicantAccountID, int applicantID)
        {
            InitializeComponent();
            _applicantAccountID = applicantAccountID;
            _applicantID = applicantID;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void ApplicantProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "SELECT * FROM Applicants WHERE ApplicantID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _applicantID);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    txtMiddleName.Text = reader["MiddleName"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    cmbGender.Text = reader["Gender"].ToString();

                    if (reader["DateOfBirth"] != DBNull.Value)
                        dtpDOB.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (firstName == "" || lastName == "")
            {
                MessageBox.Show("First Name and Last Name are required.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                string query = "UPDATE Applicants SET " +
                               "FirstName=@firstName, LastName=@lastName, " +
                               "MiddleName=@middleName, Phone=@phone, " +
                               "Address=@address, DateOfBirth=@dob, Gender=@gender " +
                               "WHERE ApplicantID=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@middleName", txtMiddleName.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dtpDOB.Value.Date);
                cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@id", _applicantID);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Profile saved successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving profile: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
