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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            // Validation
            if (firstName == "" || lastName == "" ||
                email == "" || password == "" || confirm == "")
            {
                MessageBox.Show("Please fill in all fields.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Check for duplicate email
                string checkQuery = "SELECT COUNT(*) FROM ApplicantAccounts " +
                                    "WHERE Email=@email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@email", email);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (exists > 0)
                {
                    MessageBox.Show("That email is already registered.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }

                // Insert into ApplicantAccounts
                string insertAccount = "INSERT INTO ApplicantAccounts (Email, PasswordHash) " +
                                       "VALUES (@email, @password)";
                MySqlCommand accCmd = new MySqlCommand(insertAccount, conn);
                accCmd.Parameters.AddWithValue("@email", email);
                accCmd.Parameters.AddWithValue("@password", password);
                accCmd.ExecuteNonQuery();

                // Get the new account ID
                int newAccountID = Convert.ToInt32(accCmd.LastInsertedId);

                // Insert into Applicants profile table
                string insertApplicant = "INSERT INTO Applicants " +
                                         "(ApplicantAccountID, FirstName, LastName) " +
                                         "VALUES (@accountID, @firstName, @lastName)";
                MySqlCommand appCmd = new MySqlCommand(insertApplicant, conn);
                appCmd.Parameters.AddWithValue("@accountID", newAccountID);
                appCmd.Parameters.AddWithValue("@firstName", firstName);
                appCmd.Parameters.AddWithValue("@lastName", lastName);
                appCmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Account created successfully! You can now log in.",
                                "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Go back to login
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
