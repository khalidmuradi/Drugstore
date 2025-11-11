using System;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DrugstoreManagement
{
    public static class PasswordHelper
    {
        public static string GenerateSalt(int size = 16)
        {
            var rng = new RNGCryptoServiceProvider();
            var saltBytes = new byte[size];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combined = Encoding.UTF8.GetBytes(password + salt);
                var hash = sha256.ComputeHash(combined);
                return Convert.ToBase64String(hash);
            }
        }

        // Legacy helper: compute hex-encoded SHA-256 (lowercase) to match older stored PasswordHash values
        public static string ComputeSha256Hex(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(bytes.Length * 2);
                foreach (var b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }

    public class UserService
    {
        // Updated: RegisterUser method to match the full Users table schema and use DatabaseHelper's ExecuteNonQuery
        public void RegisterUser(string username, string password, string fullName, string role, string email = null, bool isActive = true, bool isAdmin = false)
        {
            string salt = PasswordHelper.GenerateSalt();
            string hash = PasswordHelper.HashPassword(password, salt);

            // Use bracketed identifiers to avoid reserved-word collisions in MS Access
            // Insert into all relevant columns, setting PasswordResetTokenHash and PasswordResetExpiry to NULL by default
            string sql = @"
                INSERT INTO Users 
                ([Username], [Password], [PasswordSalt], [FullName], [Role], [IsActive], [IsAdmin], [Email], [PasswordResetTokenHash], [PasswordResetExpiry]) 
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, NULL, NULL)";

            OleDbParameter[] parameters = {
                new OleDbParameter("Username", username),
                new OleDbParameter("Password", hash), // Stores the hashed password (password + salt)
                new OleDbParameter("PasswordSalt", salt), // Stores the salt
                new OleDbParameter("FullName", fullName),
                new OleDbParameter("Role", role),
                new OleDbParameter("IsActive", isActive),
                new OleDbParameter("IsAdmin", isAdmin),
                new OleDbParameter("Email", (object)email ?? DBNull.Value) // Handle nullable email
            };

            using (var db = new DatabaseHelper())
            {
                db.ExecuteNonQuery(sql, parameters);
            }
        }

        // Updated: AuthenticateUser to use DatabaseHelper's ExecuteQuery for consistent connection management
        public bool AuthenticateUser(string username, string inputPassword)
        {
            // First attempt: modern schema with Password + PasswordSalt columns (password stored as Base64 hash of password+salt)
            string modernSql = "SELECT Id, Password, PasswordSalt, IsAdmin FROM Users WHERE Username = ?";
            try
            {
                using (var db = new DatabaseHelper())
                {
                    OleDbParameter[] modernParams = { new OleDbParameter("Username", username) };
                    DataTable dt = db.ExecuteQuery(modernSql, modernParams);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        // Some schemas may have nulls; guard access
                        object oPassword = row["Password"];
                        object oSalt = row["PasswordSalt"];

                        if (oPassword != DBNull.Value && oSalt != DBNull.Value)
                        {
                            string storedHash = Convert.ToString(oPassword);
                            string storedSalt = Convert.ToString(oSalt);

                            string inputHash = PasswordHelper.HashPassword(inputPassword, storedSalt);
                            if (string.Equals(storedHash, inputHash, StringComparison.Ordinal))
                            {
                                // Authentication successful with modern schema
                                return true;
                            }
                        }
                    }
                }
            }
            catch (OleDbException)
            {
                // Fall through to legacy handling below if columns don't exist or query fails
            }

            // Fallback: legacy schema where passwords were stored as SHA-256 hex in column PasswordHash
            string legacySql = "SELECT Id, PasswordHash, IsAdmin FROM Users WHERE Username = ?";
            try
            {
                using (var db = new DatabaseHelper())
                {
                    OleDbParameter[] legacyParams = { new OleDbParameter("Username", username) };
                    DataTable dt = db.ExecuteQuery(legacySql, legacyParams);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        if (row["PasswordHash"] != DBNull.Value)
                        {
                            string storedHex = row["PasswordHash"].ToString();
                            string inputHex = PasswordHelper.ComputeSha256Hex(inputPassword);
                            if (string.Equals(storedHex, inputHex, StringComparison.OrdinalIgnoreCase))
                            {
                                // Authentication successful with legacy schema
                                return true;
                            }
                        }
                    }
                }
            }
            catch (OleDbException)
            {
                // no-op; authentication will fail below
            }

            return false;
        }
    }
}
