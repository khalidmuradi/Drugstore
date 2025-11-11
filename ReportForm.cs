using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugstoreManagement
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Set default date range (current month)
            dateFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTo.Value = DateTime.Today;

            // Load report types
            comboReportType.Items.AddRange(new string[] {
                "Sales Report",
                "Purchase Report",
                "Profit Report",
                "Inventory Report",
                "Expiry Report"
            });
            comboReportType.SelectedIndex = 0;

            // Hide filters initially
            groupBoxFilters.Visible = false;
        }

        private void comboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show/hide and configure filters based on report type
            groupBoxFilters.Visible = true;
            groupBoxFilters.Text = "Filters";
            groupBoxFilters.Controls.Clear();

            switch (comboReportType.SelectedItem.ToString())
            {
                case "Sales Report":
                    AddSalesReportFilters();
                    break;
                case "Purchase Report":
                    AddPurchaseReportFilters();
                    break;
                case "Profit Report":
                    AddProfitReportFilters();
                    break;
                case "Inventory Report":
                    AddInventoryReportFilters();
                    break;
                case "Expiry Report":
                    AddExpiryReportFilters();
                    break;
            }
        }

        private void AddSalesReportFilters()
        {
            groupBoxFilters.Text = "Sales Report Filters";

            // Drug filter
            Label lblDrug = new Label();
            lblDrug.Text = "Drug:";
            lblDrug.Location = new Point(10, 20);
            lblDrug.Width = 80;

            ComboBox comboDrug = new ComboBox();
            comboDrug.Name = "comboDrug";
            comboDrug.Location = new Point(90, 20);
            comboDrug.Width = 150;

            // Load drugs
            DatabaseHelper db = new DatabaseHelper();
            string query = "SELECT DrugID, Name FROM Drugs ORDER BY Name";
            DataTable dt = db.ExecuteQuery(query);
            comboDrug.DataSource = dt;
            comboDrug.DisplayMember = "Name";
            comboDrug.ValueMember = "DrugID";
            comboDrug.SelectedIndex = -1;

            groupBoxFilters.Controls.Add(lblDrug);
            groupBoxFilters.Controls.Add(comboDrug);

            // Payment type filter
            Label lblPaymentType = new Label();
            lblPaymentType.Text = "Payment Type:";
            lblPaymentType.Location = new Point(10, 50);
            lblPaymentType.Width = 80;

            ComboBox comboPaymentType = new ComboBox();
            comboPaymentType.Name = "comboPaymentType";
            comboPaymentType.Location = new Point(90, 50);
            comboPaymentType.Width = 150;
            comboPaymentType.Items.AddRange(new string[] { "All", "Cash", "Credit" });
            comboPaymentType.SelectedIndex = 0;

            groupBoxFilters.Controls.Add(lblPaymentType);
            groupBoxFilters.Controls.Add(comboPaymentType);
        }

        private void AddPurchaseReportFilters()
        {
            groupBoxFilters.Text = "Purchase Report Filters";

            // Supplier filter
            Label lblSupplier = new Label();
            lblSupplier.Text = "Supplier:";
            lblSupplier.Location = new Point(10, 20);
            lblSupplier.Width = 80;

            ComboBox comboSupplier = new ComboBox();
            comboSupplier.Name = "comboSupplier";
            comboSupplier.Location = new Point(90, 20);
            comboSupplier.Width = 150;

            // Load suppliers
            DatabaseHelper db = new DatabaseHelper();
            string query = "SELECT SupplierID, Name FROM Suppliers ORDER BY Name";
            DataTable dt = db.ExecuteQuery(query);
            comboSupplier.DataSource = dt;
            comboSupplier.DisplayMember = "Name";
            comboSupplier.ValueMember = "SupplierID";
            comboSupplier.SelectedIndex = -1;

            groupBoxFilters.Controls.Add(lblSupplier);
            groupBoxFilters.Controls.Add(comboSupplier);
        }

        private void AddProfitReportFilters()
        {
            groupBoxFilters.Text = "Profit Report Filters";
            // No special filters for profit report
            Label lblInfo = new Label();
            lblInfo.Text = "Profit is calculated as (Sell Price - Purchase Price) * Quantity";
            lblInfo.Location = new Point(10, 20);
            lblInfo.Width = 300;
            lblInfo.Height = 40;

            groupBoxFilters.Controls.Add(lblInfo);
        }

        private void AddInventoryReportFilters()
        {
            groupBoxFilters.Text = "Inventory Report Filters";

            // Stock status filter
            Label lblStatus = new Label();
            lblStatus.Text = "Stock Status:";
            lblStatus.Location = new Point(10, 20);
            lblStatus.Width = 80;

            ComboBox comboStatus = new ComboBox();
            comboStatus.Name = "comboStatus";
            comboStatus.Location = new Point(90, 20);
            comboStatus.Width = 150;
            comboStatus.Items.AddRange(new string[] { "All", "Normal", "Low Stock", "Out of Stock" });
            comboStatus.SelectedIndex = 0;

            groupBoxFilters.Controls.Add(lblStatus);
            groupBoxFilters.Controls.Add(comboStatus);
        }

        private void AddExpiryReportFilters()
        {
            groupBoxFilters.Text = "Expiry Report Filters";

            // Expiry range filter
            Label lblExpiryRange = new Label();
            lblExpiryRange.Text = "Expires Within:";
            lblExpiryRange.Location = new Point(10, 20);
            lblExpiryRange.Width = 80;

            ComboBox comboExpiryRange = new ComboBox();
            comboExpiryRange.Name = "comboExpiryRange";
            comboExpiryRange.Location = new Point(90, 20);
            comboExpiryRange.Width = 150;
            comboExpiryRange.Items.AddRange(new string[] { "30 days", "60 days", "90 days", "All expiring" });
            comboExpiryRange.SelectedIndex = 0;

            groupBoxFilters.Controls.Add(lblExpiryRange);
            groupBoxFilters.Controls.Add(comboExpiryRange);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string reportType = comboReportType.SelectedItem.ToString();
            DateTime fromDate = dateFrom.Value;
            DateTime toDate = dateTo.Value;

            // Adjust toDate to include the entire day
            toDate = toDate.AddDays(1).AddSeconds(-1);

            switch (reportType)
            {
                case "Sales Report":
                    GenerateSalesReport(fromDate, toDate);
                    break;
                case "Purchase Report":
                    GeneratePurchaseReport(fromDate, toDate);
                    break;
                case "Profit Report":
                    GenerateProfitReport(fromDate, toDate);
                    break;
                case "Inventory Report":
                    GenerateInventoryReport();
                    break;
                case "Expiry Report":
                    GenerateExpiryReport();
                    break;
            }
        }

        private void GenerateSalesReport(DateTime fromDate, DateTime toDate)
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT 
                    s.SaleDate,
                    d.Name as DrugName,
                    d.Company,
                    s.Quantity,
                    s.SellPrice,
                    s.DiscountAmount,
                    s.BorrowAmount,
                    s.TotalPrice,
                    IIF(s.IsPrescriptionSale = 1, 'Prescription', 'Direct') as SaleType
                FROM Sales s
                INNER JOIN Drugs d ON s.DrugID = d.DrugID
                WHERE s.SaleDate BETWEEN ? AND ?";

            // Apply filters
            ComboBox comboDrug = groupBoxFilters.Controls["comboDrug"] as ComboBox;
            ComboBox comboPaymentType = groupBoxFilters.Controls["comboPaymentType"] as ComboBox;

            var parameters = new List<OleDbParameter> {
                new OleDbParameter("FromDate", fromDate),
                new OleDbParameter("ToDate", toDate)
            };

            if (comboDrug != null && comboDrug.SelectedValue != null)
            {
                query += " AND s.DrugID = ?";
                parameters.Add(new OleDbParameter("DrugID", comboDrug.SelectedValue));
            }

            if (comboPaymentType != null && comboPaymentType.SelectedIndex > 0)
            {
                query += " AND s.BorrowAmount " + (comboPaymentType.SelectedItem.ToString() == "Cash" ? "= 0" : "> 0");
            }

            query += " ORDER BY s.SaleDate DESC";

            DataTable dt = db.ExecuteQuery(query, parameters.ToArray());
            dataGridViewReport.DataSource = dt;

            // Calculate and display summary
            decimal totalSales = 0;
            decimal totalDiscount = 0;
            decimal totalBorrow = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalSales += Convert.ToDecimal(row["TotalPrice"]);
                totalDiscount += Convert.ToDecimal(row["DiscountAmount"]);
                totalBorrow += Convert.ToDecimal(row["BorrowAmount"]);
            }

            lblSummary.Text = $"Total Sales: {totalSales:N2} Afghani | Discount: {totalDiscount:N2} | Credit: {totalBorrow:N2}";
        }

        private void GeneratePurchaseReport(DateTime fromDate, DateTime toDate)
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT 
                    p.PurchaseDate,
                    d.Name as DrugName,
                    d.Company,
                    s.Name as SupplierName,
                    p.Quantity,
                    p.PurchasePrice,
                    (p.Quantity * p.PurchasePrice) as TotalAmount
                FROM Purchases p
                INNER JOIN Drugs d ON p.DrugID = d.DrugID
                LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID
                WHERE p.PurchaseDate BETWEEN ? AND ?";

            ComboBox comboSupplier = groupBoxFilters.Controls["comboSupplier"] as ComboBox;
            var parameters = new List<OleDbParameter> {
                new OleDbParameter("FromDate", fromDate),
                new OleDbParameter("ToDate", toDate)
            };

            if (comboSupplier != null && comboSupplier.SelectedValue != null)
            {
                query += " AND p.SupplierID = ?";
                parameters.Add(new OleDbParameter("SupplierID", comboSupplier.SelectedValue));
            }

            query += " ORDER BY p.PurchaseDate DESC";

            DataTable dt = db.ExecuteQuery(query, parameters.ToArray());
            dataGridViewReport.DataSource = dt;

            // Calculate and display summary
            decimal totalPurchases = 0;
            int totalItems = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalPurchases += Convert.ToDecimal(row["TotalAmount"]);
                totalItems += Convert.ToInt32(row["Quantity"]);
            }

            lblSummary.Text = $"Total Purchases: {totalPurchases:N2} Afghani | Items: {totalItems}";
        }

        private void GenerateProfitReport(DateTime fromDate, DateTime toDate)
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT 
                    s.SaleDate,
                    d.Name as DrugName,
                    d.Company,
                    s.Quantity,
                    s.SellPrice,
                    d.PurchasePrice,
                    (s.SellPrice - d.PurchasePrice) as ProfitPerUnit,
                    (s.SellPrice - d.PurchasePrice) * s.Quantity as TotalProfit,
                    s.TotalPrice as SaleAmount
                FROM Sales s
                INNER JOIN Drugs d ON s.DrugID = d.DrugID
                WHERE s.SaleDate BETWEEN ? AND ?
                ORDER BY s.SaleDate DESC";

            OleDbParameter[] parameters = {
                new OleDbParameter("FromDate", fromDate),
                new OleDbParameter("ToDate", toDate)
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            dataGridViewReport.DataSource = dt;

            // Calculate and display summary
            decimal totalProfit = 0;
            decimal totalSales = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalProfit += Convert.ToDecimal(row["TotalProfit"]);
                totalSales += Convert.ToDecimal(row["SaleAmount"]);
            }

            decimal profitMargin = totalSales > 0 ? (totalProfit / totalSales) * 100 : 0;

            lblSummary.Text = $"Total Profit: {totalProfit:N2} Afghani | Profit Margin: {profitMargin:N2}%";
        }

        private void GenerateInventoryReport()
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT 
                    d.Name as DrugName,
                    d.Company,
                    d.Dosage,
                    d.Type,
                    i.Stock,
                    d.PurchasePrice,
                    i.Stock * d.PurchasePrice as InventoryValue,
                    IIF(i.Stock = 0, 'Out of Stock', IIF(i.Stock < 10, 'Low Stock', 'Normal')) as StockStatus
                FROM Drugs d
                INNER JOIN Inventory i ON d.DrugID = i.DrugID";

            ComboBox comboStatus = groupBoxFilters.Controls["comboStatus"] as ComboBox;

            if (comboStatus != null && comboStatus.SelectedIndex > 0)
            {
                string statusFilter = comboStatus.SelectedItem.ToString();
                if (statusFilter == "Low Stock")
                {
                    query += " WHERE i.Stock < 10 AND i.Stock > 0";
                }
                else if (statusFilter == "Out of Stock")
                {
                    query += " WHERE i.Stock = 0";
                }
            }

            query += " ORDER BY d.Name";

            DataTable dt = db.ExecuteQuery(query);
            dataGridViewReport.DataSource = dt;

            // Calculate and display summary
            decimal totalValue = 0;
            int lowStockItems = 0;
            int outOfStockItems = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalValue += Convert.ToDecimal(row["InventoryValue"]);

                if (Convert.ToInt32(row["Stock"]) == 0)
                {
                    outOfStockItems++;
                }
                else if (Convert.ToInt32(row["Stock"]) < 10)
                {
                    lowStockItems++;
                }
            }

            lblSummary.Text = $"Total Inventory Value: {totalValue:N2} Afghani | Low Stock: {lowStockItems} | Out of Stock: {outOfStockItems}";
        }

        private void GenerateExpiryReport()
        {
            DatabaseHelper db = new DatabaseHelper();

            // Determine expiry range
            int daysThreshold = 30;
            ComboBox comboExpiryRange = groupBoxFilters.Controls["comboExpiryRange"] as ComboBox;

            if (comboExpiryRange != null)
            {
                switch (comboExpiryRange.SelectedItem.ToString())
                {
                    case "60 days":
                        daysThreshold = 60;
                        break;
                    case "90 days":
                        daysThreshold = 90;
                        break;
                    case "All expiring":
                        daysThreshold = 365; // Show all drugs expiring within a year
                        break;
                }
            }

            string query = @"
                SELECT 
                    d.Name as DrugName,
                    d.Company,
                    d.Dosage,
                    d.ExpiryDate,
                    i.Stock,
                    (d.ExpiryDate - DATE()) as DaysUntilExpiry,
                    IIF(d.ExpiryDate < DATE(), 'Expired', IIF((d.ExpiryDate - DATE()) <= 30, 'Expiring Soon', 'Not Expiring Soon')) as ExpiryStatus
                FROM Drugs d
                INNER JOIN Inventory i ON d.DrugID = i.DrugID
                WHERE d.ExpiryDate <= DATEADD('d', ?, DATE())
                ORDER BY d.ExpiryDate";

            OleDbParameter[] parameters = {
                new OleDbParameter("DaysThreshold", daysThreshold)
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            dataGridViewReport.DataSource = dt;

            // Calculate and display summary
            int expiredItems = 0;
            int expiringSoonItems = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToDateTime(row["ExpiryDate"]) < DateTime.Today)
                {
                    expiredItems++;
                }
                else if (Convert.ToInt32(row["DaysUntilExpiry"]) <= 30)
                {
                    expiringSoonItems++;
                }
            }

            lblSummary.Text = $"Expired Items: {expiredItems} | Expiring Soon (30 days): {expiringSoonItems}";
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewReport.DataSource == null)
            {
                MessageBox.Show("Please generate a report first.");
                return;
            }

            ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;

                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                // Add title
                var titleCell = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
                titleCell.Value2 = comboReportType.SelectedItem + " Report";
                titleCell.Font.Bold = true;
                titleCell.Font.Size = 16;

                // Add date range
                var dateCell = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1];
                dateCell.Value2 = $"Date Range: {dateFrom.Value:yyyy-MM-dd} to {dateTo.Value:yyyy-MM-dd}";

                // Add summary
                var summaryCell = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 1];
                summaryCell.Value2 = lblSummary.Text;

                // Add column headers
                for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                {
                    var headerCell = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[5, i + 1];
                    headerCell.Value2 = dataGridViewReport.Columns[i].HeaderText;
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // Add data
                for (int i = 0; i < dataGridViewReport.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewReport.Columns.Count; j++)
                    {
                        if (dataGridViewReport.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 6, j + 1] = dataGridViewReport.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                MessageBox.Show("Report exported to Excel successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF export functionality would be implemented here with a library like iTextSharp.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print functionality would be implemented here.");
        }
    }
}