using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace DrugstoreManagement
{
    public partial class ReportViewerForm : Form
    {
        public ReportViewerForm()
        {
            InitializeComponent();
        }

        // accdbPath: full path to .accdb file
        // query: SQL SELECT that returns the columns the RDLC expects
        // reportPath: path to your .rdlc file (can be embedded or file path)
        // datasetName: name of the DataSet defined in the RDLC (e.g. "DataSet1")
        public void LoadReportFromAccess(string accdbPath, string query, string reportPath, string datasetName)
        {
            string connString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accdbPath};Persist Security Info=False;";
            DataTable dt = new DataTable();

            using (var conn = new OleDbConnection(connString))
            using (var adapter = new OleDbDataAdapter(query, conn))
            {
                adapter.Fill(dt);
            }

            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = reportPath; // or use ReportEmbeddedResource if embedded
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(datasetName, dt));
            reportViewer1.RefreshReport();
        }
    }
}