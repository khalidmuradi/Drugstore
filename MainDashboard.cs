using System;
using System.Data;
using System.Windows.Forms;

namespace DrugstoreManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            using (DatabaseHelper db = new DatabaseHelper())
            {
                // Load today's sales
                string salesQuery = @"
                    SELECT COUNT(*) as SalesCount, Nz(SUM(TotalPrice), 0) as SalesTotal
                    FROM Sales
                    WHERE DateValue(SaleDate) = Date()";

                DataTable salesDt = db.ExecuteQuery(salesQuery);
                lblTodaySalesCount.Text = salesDt.Rows[0]["SalesCount"].ToString();
                lblTodaySalesTotal.Text = $"{salesDt.Rows[0]["SalesTotal"]} Afghani";

                // Load low stock alerts
                string lowStockQuery = "SELECT COUNT(*) FROM Inventory WHERE Stock < 10 AND Stock > 0";
                object lowStockCount = db.ExecuteScalar(lowStockQuery);
                lblLowStock.Text = lowStockCount.ToString();

                // Load out of stock alerts
                string outOfStockQuery = "SELECT COUNT(*) FROM Inventory WHERE Stock = 0";
                object outOfStockCount = db.ExecuteScalar(outOfStockQuery);
                lblOutOfStock.Text = outOfStockCount.ToString();

                // Load expiry alerts (drugs expiring in next 30 days)
                string expiryQuery = @"
                    SELECT COUNT(*)
                    FROM Drugs
                    WHERE ExpiryDate BETWEEN Date() AND DateAdd('d', 30, Date())";
                object expiryCount = db.ExecuteScalar(expiryQuery);
                lblExpiryAlert.Text = expiryCount.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnDrugManagement_Click(object sender, EventArgs e)
        {
            DrugManagementForm drugForm = new DrugManagementForm();
            drugForm.ShowDialog();
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            PurchaseForm purchasesForm = new PurchaseForm();
            purchasesForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm reportsForm = new ReportForm();
            reportsForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}