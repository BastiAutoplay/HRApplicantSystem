using HRApplicantSystem.Database;
using HRApplicantSystem.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check for empty fields
            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter your email and password.",
                                "Warning", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlConnection conn = DBConnection.GetConnection();
                conn.Open();

                // Check HR/Admin Users table first
                string hrQuery = "SELECT UserID, FullName, RoleID FROM Users " +
                                 "WHERE Email=@email AND PasswordHash=@password " +
                                 "AND IsActive=1";

                MySqlCommand hrCmd = new MySqlCommand(hrQuery, conn);
                hrCmd.Parameters.AddWithValue("@email", email);
                hrCmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader hrReader = hrCmd.ExecuteReader();

                if (hrReader.Read())
                {
                    string fullName = hrReader["FullName"].ToString();
                    int roleID = Convert.ToInt32(hrReader["RoleID"]);
                    hrReader.Close();
                    conn.Close();

                    MessageBox.Show("Welcome, " + fullName + "!",
                                   "Login Successful",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                    // We'll open HR Dashboard here later
                    return;
                }

                hrReader.Close();

                // If not HR, check Applicant accounts
                string appQuery = "SELECT ApplicantAccountID, Email FROM ApplicantAccounts " +
                                  "WHERE Email=@email AND PasswordHash=@password " +
                                  "AND IsActive=1";

                MySqlCommand appCmd = new MySqlCommand(appQuery, conn);
                appCmd.Parameters.AddWithValue("@email", email);
                appCmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader appReader = appCmd.ExecuteReader();

                if (appReader.Read())
                {
                    int accountID = Convert.ToInt32(appReader["ApplicantAccountID"]);
                    appReader.Close();
                    conn.Close();

                    ApplicantDashboard dashboard = new ApplicantDashboard(accountID);
                    dashboard.Show();
                    this.Hide();
                    return;
                }

                appReader.Close();
                conn.Close();

                // If neither matched
                MessageBox.Show("Invalid email or password.",
                               "Login Failed",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                               "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
