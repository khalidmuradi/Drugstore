using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Windows.Forms; -- moved to designer where needed
using System.Data.OleDb;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DrugstoreManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Use salted hash authentication
            string query = "SELECT Id, FullName, Role, Password, PasswordSalt FROM Users WHERE Username = ? AND IsActive = 1";
            DatabaseHelper db = new DatabaseHelper();
            OleDbParameter[] parameters = {
                new OleDbParameter("Username", username)
            };
            DataTable dt = db.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                string storedHash = dt.Rows[0]["Password"].ToString();
                string storedSalt = dt.Rows[0]["PasswordSalt"].ToString();
                string inputHash = PasswordHelper.HashPassword(password, storedSalt);
                if (storedHash == inputHash)
                {
                    // Update last login
                    string updateQuery = "UPDATE Users SET LastLogin = ? WHERE Id = ?";
                    OleDbParameter[] updateParams = {
                        new OleDbParameter("LastLogin", DateTime.Now),
                        new OleDbParameter("Id", dt.Rows[0]["Id"])
                    };
                    db.ExecuteNonQuery(updateQuery, updateParams);

                    // Store user info for session
                    UserSession.UserID = Convert.ToInt32(dt.Rows[0]["Id"]);
                    UserSession.FullName = dt.Rows[0]["FullName"].ToString();
                    UserSession.Role = dt.Rows[0]["Role"].ToString();

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Invalid username or password.");
        }
    }

    public static class UserSession
    {
        public static int UserID { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }
    }
}