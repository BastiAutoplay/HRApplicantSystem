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
    public partial class HRLoginForm : Form
    {
        private int _userID;
        private int _roleID;
        private string _fullName;

        public HRLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

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

                string query = "SELECT UserID, FullName, RoleID FROM Users " +
                               "WHERE Email=@email AND PasswordHash=@password " +
                               "AND IsActive=1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _userID = Convert.ToInt32(reader["UserID"]);
                    _roleID = Convert.ToInt32(reader["RoleID"]);
                    _fullName = reader["FullName"].ToString();
                    reader.Close();
                    conn.Close();

                    // Open HR Dashboard
                    HRDashboardForm dashboard = new HRDashboardForm(
                        _userID, _roleID, _fullName);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    reader.Close();
                    conn.Close();
                    MessageBox.Show("Invalid email or password.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
