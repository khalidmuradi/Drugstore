using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb; // Use OleDb for MS Access
using System.Configuration;
using System.Windows.Forms;

namespace DrugstoreManagement // Removed extra spaces
{
    public class DatabaseHelper : IDisposable
    {
        private OleDbConnection _connection;
        private bool _disposed;

        public DatabaseHelper()
        {
            try
            {
                // Update to use MS Access connection string name
                _connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["DrugstoreDBConnection"]?.ConnectionString ?? string.Empty);

                if (string.IsNullOrWhiteSpace(_connection.ConnectionString))
                {
                    throw new ConfigurationErrorsException(
                        "The ConnectionString property has not been initialized. Please check your App.config file for a connection string named 'DrugstoreDBConnection'.");
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show($"Configuration Error: {ex.Message}\n\n" +
                               "Please ensure the App.config file exists with a valid connection string.\n" +
                               "Example connection string: Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\DrugstoreDB.accdb;Persist Security Info=False;",
                               "Configuration Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                throw;
            }
        }

        public DataTable ExecuteQuery(string query, OleDbParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            bool openedHere = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    if (_connection.State == ConnectionState.Broken)
                        _connection.Close();
                    _connection.Open();
                    openedHere = true;
                }

                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            finally
            {
                if (openedHere)
                    _connection.Close();
            }
            return dt;
        }

        public int ExecuteNonQuery(string query, OleDbParameter[] parameters = null)
        {
            bool openedHere = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    if (_connection.State == ConnectionState.Broken)
                        _connection.Close();
                    _connection.Open();
                    openedHere = true;
                }

                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (openedHere)
                    _connection.Close();
            }
        }

        public object ExecuteScalar(string query, OleDbParameter[] parameters = null)
        {
            bool openedHere = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    if (_connection.State == ConnectionState.Broken)
                        _connection.Close();
                    _connection.Open();
                    openedHere = true;
                }

                using (OleDbCommand cmd = new OleDbCommand(query, _connection))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
            finally
            {
                if (openedHere)
                    _connection.Close();
            }
        }

        public bool TestConnection(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                // Optional: report DataDirectory resolution for debugging
                try
                {
                    var dataDir = AppDomain.CurrentDomain.GetData("DataDirectory")?.ToString();
                    if (!string.IsNullOrEmpty(dataDir))
                    {
                        // Non-fatal: helpful info for debugging deployments
                    }
                }
                catch { /* ignore */ }

                _connection.Open(); // will throw if cannot connect / provider missing / file missing
                                    // Optionally run a trivial query to ensure SQL is supported by the backend:
                                    // using (var cmd = new OleDbCommand("SELECT COUNT(*) FROM Users", conn)) { cmd.ExecuteScalar(); }
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                // return the full message to the caller for display/logging
                errorMessage = ex.Message;
                return false;
            }
        }

        // Updated: InsertUser method to include new columns from the schema
        public void InsertUser(string username, string password, string fullName, string role, string email = null, bool isActive = true, bool isAdmin = false)
        {
            string salt = PasswordHelper.GenerateSalt();
            string hashedPassword = PasswordHelper.HashPassword(password, salt);
            // Use bracketed identifiers to avoid reserved-word collisions in MS Access
            // Added Email, PasswordResetTokenHash, PasswordResetExpiry (defaulting to NULL)
            string query = "INSERT INTO Users ([Username], [Password], [PasswordSalt], [FullName], [Role], [IsActive], [IsAdmin], [Email], [PasswordResetTokenHash], [PasswordResetExpiry]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, NULL, NULL)";
            OleDbParameter[] parameters = {
                new OleDbParameter("Username", username),
                new OleDbParameter("Password", hashedPassword),
                new OleDbParameter("PasswordSalt", salt),
                new OleDbParameter("FullName", fullName),
                new OleDbParameter("Role", role),
                new OleDbParameter("IsActive", isActive),
                new OleDbParameter("IsAdmin", isAdmin),
                new OleDbParameter("Email", (object)email ?? DBNull.Value) // Handle nullable email
            };
            ExecuteNonQuery(query, parameters);
        }

        // Updated: method to change a user's password
        public void UpdateUserPassword(string username, string newPassword)
        {
            string salt = PasswordHelper.GenerateSalt();
            string hashedPassword = PasswordHelper.HashPassword(newPassword, salt);
            // Bracketed identifiers and positional parameters (OleDb uses ? placeholders)
            string update = "UPDATE Users SET [Password] = ?, [PasswordSalt] = ? WHERE [Username] = ?";
            OleDbParameter[] parameters = {
                new OleDbParameter("Password", hashedPassword),
                new OleDbParameter("PasswordSalt", salt),
                new OleDbParameter("Username", username)
            };
            ExecuteNonQuery(update, parameters);
        }

        public void Dispose()
        {
            if (_disposed) return;
            try
            {
                if (_connection != null)
                {
                    if (_connection.State != System.Data.ConnectionState.Closed)
                        _connection.Close();
                    _connection.Dispose();
                    _connection = null;
                }
            }
            catch { }
            _disposed = true;
        }

        public OleDbConnection Connection => _connection;
    }
}
