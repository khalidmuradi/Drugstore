using System;
using System.Windows.Forms;

namespace DrugstoreManagement
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Quick connection test before continuing
            try
            {
                using (var db = new DatabaseHelper())
                {
                    if (!db.TestConnection(out string err))
                    {
                        MessageBox.Show("Database connection failed:\n\n" + err, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // stop app to fix configuration
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize database helper:\n\n" + ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize database and run app
            InitializeDatabase();
            Application.Run(new LoginForm());
        }

        static void InitializeDatabase()
        {
            DatabaseInitializer initializer = new DatabaseInitializer();
            initializer.InitializeDatabase();
        }
    }
}