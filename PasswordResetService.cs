using System;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace DrugstoreManagement
{
    public class PasswordResetService
    {
        // Token lifetime (UTC)
        private readonly TimeSpan _tokenLifetime = TimeSpan.FromHours(1);

        // Request a reset: creates a secure token, stores its hash + expiry, and returns token (for sending)
        public string RequestPasswordReset(string username, string userEmail)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException(nameof(username));

            // Generate a URL-safe token
            string token = GenerateToken(32);
            string tokenHash = ComputeSha256(token);
            DateTime expiryUtc = DateTime.UtcNow.Add(_tokenLifetime);

            using (var db = new DatabaseHelper())
            {
                using (var cmd = new OleDbCommand("UPDATE Users SET PasswordResetTokenHash = ?, PasswordResetExpiry = ? WHERE Username = ?", db.Connection))
                {
                    cmd.Parameters.AddWithValue("?", tokenHash);
                    cmd.Parameters.AddWithValue("?", expiryUtc);
                    cmd.Parameters.AddWithValue("?", username);

                    db.Connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    db.Connection.Close();

                    if (rows == 0)
                        throw new InvalidOperationException("User not found.");
                }
            }

            // Send the token to the user via email (you can also return it for UI to display a link).
            SendResetEmail(userEmail, username, token, expiryUtc);

            return token; // Useful in tests or if you need to build the link elsewhere
        }

        // Reset a user's password using the provided token
        public bool ResetPassword(string token, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(token)) return false;
            if (string.IsNullOrWhiteSpace(newPassword)) return false;

            string tokenHash = ComputeSha256(token);
            DateTime nowUtc = DateTime.UtcNow;

            int userId = -1;
            using (var db = new DatabaseHelper())
            {
                using (var cmd = new OleDbCommand("SELECT Id FROM Users WHERE PasswordResetTokenHash = ? AND PasswordResetExpiry >= ?", db.Connection))
                {
                    cmd.Parameters.AddWithValue("?", tokenHash);
                    cmd.Parameters.AddWithValue("?", nowUtc);

                    db.Connection.Open();
                    object obj = cmd.ExecuteScalar();
                    db.Connection.Close();

                    if (obj == null || obj == DBNull.Value) return false;
                    userId = Convert.ToInt32(obj);
                }

                // Compute new salt and password hash
                string salt = PasswordHelper.GenerateSalt();
                string hashed = PasswordHelper.HashPassword(newPassword, salt);

                using (var update = new OleDbCommand("UPDATE Users SET Password = ?, PasswordSalt = ?, PasswordResetTokenHash = NULL, PasswordResetExpiry = NULL WHERE Id = ?", db.Connection))
                {
                    update.Parameters.AddWithValue("?", hashed);
                    update.Parameters.AddWithValue("?", salt);
                    update.Parameters.AddWithValue("?", userId);

                    db.Connection.Open();
                    int updated = update.ExecuteNonQuery();
                    db.Connection.Close();

                    return updated > 0;
                }
            }
        }

        // Utility: generate cryptographically secure random token (base64 URL-safe)
        private string GenerateToken(int byteSize)
        {
            byte[] bytes = new byte[byteSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            string base64 = Convert.ToBase64String(bytes);
            // Make URL-safe
            return base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
        }

        private string ComputeSha256(string value)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Example email send - configure SMTP details to match your environment.
        private void SendResetEmail(string toEmail, string username, string token, DateTime expiryUtc)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) return;

            // Build a URL for the password reset page in your app (example)
            // If your app is desktop-only, you may show the token in the UI instead.
            string resetLink = $"https://example.com/reset?user={Uri.EscapeDataString(username)}&token={Uri.EscapeDataString(token)}";

            string body = $"Hello {username},\n\n" +
                          $"A password reset was requested. Use the following link to reset your password (expires {expiryUtc:u} UTC):\n\n" +
                          $"{resetLink}\n\n" +
                          $"If you did not request this, ignore this message.";

            // Replace the placeholders below with your SMTP server and credentials
            var msg = new MailMessage("no-reply@example.com", toEmail, "Password reset request", body);
            using (var client = new SmtpClient("smtp.example.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("smtp-user", "smtp-password");
                client.Send(msg);
            }
        }
    }
}