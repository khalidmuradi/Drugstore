using System;
using System.Data.OleDb;

namespace DrugstoreManagement
{
    public class UserRepository
    {
        public bool AuthenticateUser(string username, string password, out bool isAdmin)
        {
            isAdmin = false;
            using (var db = new DatabaseHelper())
            {
                string query = "SELECT IsAdmin, Password, PasswordSalt FROM Users WHERE Username = ?";
                OleDbParameter[] parameters = {
                    new OleDbParameter("Username", username)
                };
                var dt = db.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    string storedHash = dt.Rows[0]["Password"].ToString();
                    string storedSalt = dt.Rows[0]["PasswordSalt"].ToString();
                    string inputHash = PasswordHelper.HashPassword(password, storedSalt);
                    if (storedHash == inputHash)
                    {
                        isAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}