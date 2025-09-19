using System;
using System.Windows.Forms;
using DrugstoreManagement;

namespace Drugstore.Runner
{
    // The runner's Main is intentionally renamed to avoid duplicate entry-point collisions
    // when the main `Drugstore` project is built in the same solution.
    internal static class RunnerProgram
    {
        // Provide a proper entry point for the runner project.
        [STAThread]
        public static void Main()
        {
            Run();
        }

        // Existing Run method preserved for clarity and potential reuse.
        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Launch the main DrugManagementForm from the primary project so UI is functional
            Application.Run(new DrugManagementForm());
        }
    }
}