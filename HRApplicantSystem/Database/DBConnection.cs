using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace HRApplicantSystem.Database
{
    public class DBConnection
    {
        // ⚠️ Change "Admin1234" to YOUR MySQL root password
        private static string connectionString =
            "Server=localhost;Database=hr_applicant_system;Uid=root;Pwd=WgPtMaCgR2;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}