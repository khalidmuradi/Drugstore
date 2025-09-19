using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DrugstoreManagement
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            comboFilter.SelectedIndex = 0; // Select "All" by default
            LoadInventoryData();
            ConfigureDataGridView();
        }

        private void LoadInventoryData(string filter = "All", string searchTerm = "")
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT 
                    d.DrugID,
                    d.Name,
                    d.Company,
                    d.Dosage,
                    d.Type,
                    d.ExpiryDate,
                    i.Stock,
                    IIF(i.Stock = 0, 'Out of Stock', IIF(i.Stock < 10, 'Low Stock', IIF(d.ExpiryDate <= DATE(), 'Expired', IIF(d.ExpiryDate <= DATEADD('d', 30, DATE()), 'Expiring Soon', 'Normal')))) as StockStatus
                FROM Drugs d
                INNER JOIN Inventory i ON d.DrugID = i.DrugID
                WHERE 1=1";

            // Apply filters
            switch (filter)
            {
                case "Low Stock":
                    query += " AND i.Stock < 10 AND i.Stock > 0";
                    break;
                case "Out of Stock":
                    query += " AND i.Stock = 0";
                    break;
                case "Expiring Soon":
                    query += " AND d.ExpiryDate <= DATEADD('d', 30, DATE()) AND d.ExpiryDate > DATE()";
                    break;
                case "Expired":
                    query += " AND d.ExpiryDate <= DATE()";
                    break;
            }

            // Apply search term
            List<OleDbParameter> parameters = new List<OleDbParameter>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " AND (d.Name LIKE ? OR d.Company LIKE ? OR d.Type LIKE ?)";
                parameters.Add(new OleDbParameter("SearchTerm1", $"%{searchTerm}%"));
                parameters.Add(new OleDbParameter("SearchTerm2", $"%{searchTerm}%"));
                parameters.Add(new OleDbParameter("SearchTerm3", $"%{searchTerm}%"));
            }

            query += " ORDER BY d.Name";

            DataTable dt = db.ExecuteQuery(query, parameters.Count > 0 ? parameters.ToArray() : null);
            dataGridViewInventory.DataSource = dt;

            // Apply formatting to the grid
            FormatDataGridView();
        }

        private void FormatExpiryDataGridView()
        {
            foreach (DataGridViewRow row in dataGridViewExpiry.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Expired":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                            break;
                        case "Expiring Soon":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                            break;
                    }
                }

                // Highlight if less than 15 days until expiry
                if (row.Cells["DaysUntilExpiry"].Value != null &&
                    int.TryParse(row.Cells["DaysUntilExpiry"].Value.ToString(), out int days))
                {
                    if (days < 0)
                    {
                        row.Cells["DaysUntilExpiry"].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (days < 15)
                    {
                        row.Cells["DaysUntilExpiry"].Style.ForeColor = System.Drawing.Color.Orange;
                    }
                }
            }
        }
        private void ConfigureDataGridView()
        {
            // Hide the DrugID column
            if (dataGridViewInventory.Columns.Contains("DrugID"))
            {
                dataGridViewInventory.Columns["DrugID"].Visible = false;
            }

            // Set column headers
            if (dataGridViewInventory.Columns.Contains("Name"))
            {
                dataGridViewInventory.Columns["Name"].HeaderText = "Drug Name";
                dataGridViewInventory.Columns["Name"].Width = 150;
            }

            if (dataGridViewInventory.Columns.Contains("Company"))
            {
                dataGridViewInventory.Columns["Company"].HeaderText = "Manufacturer";
                dataGridViewInventory.Columns["Company"].Width = 120;
            }

            if (dataGridViewInventory.Columns.Contains("Dosage"))
            {
                dataGridViewInventory.Columns["Dosage"].Width = 80;
            }

            if (dataGridViewInventory.Columns.Contains("Type"))
            {
                dataGridViewInventory.Columns["Type"].Width = 100;
            }

            if (dataGridViewInventory.Columns.Contains("ExpiryDate"))
            {
                dataGridViewInventory.Columns["ExpiryDate"].HeaderText = "Expiry Date";
                dataGridViewInventory.Columns["ExpiryDate"].Width = 100;
                dataGridViewInventory.Columns["ExpiryDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }

            if (dataGridViewInventory.Columns.Contains("Stock"))
            {
                dataGridViewInventory.Columns["Stock"].Width = 60;
            }

            if (dataGridViewInventory.Columns.Contains("StockStatus"))
            {
                dataGridViewInventory.Columns["StockStatus"].HeaderText = "Status";
                dataGridViewInventory.Columns["StockStatus"].Width = 100;
            }
        }

        private void FormatDataGridView()
        {
            foreach (DataGridViewRow row in dataGridViewInventory.Rows)
            {
                if (row.Cells["StockStatus"].Value != null)
                {
                    string status = row.Cells["StockStatus"].Value.ToString();
                    switch (status)
                    {
                        case "Out of Stock":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                        case "Low Stock":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Expired":
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                            break;
                        case "Expiring Soon":
                            row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                            break;
                    }
                }

                // Highlight expired drugs
                if (row.Cells["ExpiryDate"].Value != null &&
                    DateTime.TryParse(row.Cells["ExpiryDate"].Value.ToString(), out DateTime expiryDate))
                {
                    if (expiryDate < DateTime.Today)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    else if (expiryDate < DateTime.Today.AddDays(30))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    }
                }
            }
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboFilter.SelectedItem.ToString();
            string searchTerm = txtSearch.Text.Trim();
            LoadInventoryData(filter, searchTerm);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filter = comboFilter.SelectedItem.ToString();
            string searchTerm = txtSearch.Text.Trim();
            LoadInventoryData(filter, searchTerm);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string filter = comboFilter.SelectedItem.ToString();
            string searchTerm = txtSearch.Text.Trim();
            LoadInventoryData(filter, searchTerm);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
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
                titleCell.Value2 = "Drugstore Inventory Report";
                titleCell.Font.Bold = true;
                titleCell.Font.Size = 16;
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Range["A1:H1"]).Merge();

                // Add date
                var dateCell = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1];
                dateCell.Value2 = "Generated on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                ((Microsoft.Office.Interop.Excel.Range)worksheet.Range["A2:H2"]).Merge();

                // Add column headers
                for (int i = 0; i < dataGridViewInventory.Columns.Count; i++)
                {
                    if (dataGridViewInventory.Columns[i].Visible)
                    {
                        var headerCell = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[4, i + 1];
                        headerCell.Value2 = dataGridViewInventory.Columns[i].HeaderText;
                        headerCell.Font.Bold = true;
                        headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }
                }

                // Add data
                for (int i = 0; i < dataGridViewInventory.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewInventory.Columns.Count; j++)
                    {
                        if (dataGridViewInventory.Columns[j].Visible)
                        {
                            worksheet.Cells[i + 5, j + 1] = dataGridViewInventory.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                }

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                MessageBox.Show("Inventory exported to Excel successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            // This would require a PDF library like iTextSharp
            MessageBox.Show("PDF export functionality would be implemented here with a library like iTextSharp.");
        }

        private void btnAdjustStock_Click(object sender, EventArgs e)
        {
            if (dataGridViewInventory.CurrentRow != null)
            {
                int drugId = Convert.ToInt32(dataGridViewInventory.CurrentRow.Cells["DrugID"].Value);
                string drugName = dataGridViewInventory.CurrentRow.Cells["Name"].Value.ToString();
                int currentStock = Convert.ToInt32(dataGridViewInventory.CurrentRow.Cells["Stock"].Value);
                int newQuantity = (int)numAdjustQuantity.Value;

                if (newQuantity < 0)
                {
                    MessageBox.Show("Quantity cannot be negative.");
                    return;
                }

                AdjustStock(drugId, drugName, newQuantity, currentStock);
            }
            else
            {
                MessageBox.Show("Please select a drug to adjust stock.");
            }
        }

        private void AdjustStock(int drugId, string drugName, int newQuantity, int currentStock)
        {
            string reason = "";
            if (newQuantity > currentStock)
            {
                reason = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter reason for stock increase:", "Stock Adjustment", "");
            }
            else if (newQuantity < currentStock)
            {
                reason = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter reason for stock decrease:", "Stock Adjustment", "");
            }

            if (string.IsNullOrEmpty(reason) && newQuantity != currentStock)
            {
                MessageBox.Show("Reason is required for stock adjustment.");
                return;
            }

            DatabaseHelper db = new DatabaseHelper();
            string query = "UPDATE Inventory SET Stock = @Stock WHERE DrugID = @DrugID";

            OleDbParameter[] parameters = {
                new OleDbParameter("@Stock", newQuantity),
                new OleDbParameter("@DrugID", drugId)
            };

            int result = db.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                // Log the adjustment
                LogStockAdjustment(drugId, currentStock, newQuantity, reason);

                MessageBox.Show("Stock updated successfully.");
                btnRefresh_Click(null, null); // Refresh the grid
            }
            else
            {
                MessageBox.Show("Failed to update stock.");
            }
        }

        private void LogStockAdjustment(int drugId, int oldQuantity, int newQuantity, string reason)
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                INSERT INTO StockAdjustments (DrugID, OldQuantity, NewQuantity, AdjustmentDate, Reason, AdjustedBy)
                VALUES (@DrugID, @OldQuantity, @NewQuantity, GETDATE(), @Reason, @AdjustedBy)";

            OleDbParameter[] parameters = {
                new OleDbParameter("@DrugID", drugId),
                new OleDbParameter("@OldQuantity", oldQuantity),
                new OleDbParameter("@NewQuantity", newQuantity),
                new OleDbParameter("@Reason", reason),
                new OleDbParameter("@AdjustedBy", UserSession.UserID)
            };

            db.ExecuteNonQuery(query, parameters);
        }

        private void dataGridViewInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInventory.CurrentRow != null && dataGridViewInventory.CurrentRow.Cells["Stock"].Value != null)
            {
                int currentStock = Convert.ToInt32(dataGridViewInventory.CurrentRow.Cells["Stock"].Value);
                numAdjustQuantity.Value = currentStock;
            }
        }

        private void btnViewExpiryReport_Click(object sender, EventArgs e)
        {
            ExpiryReportForm expiryForm = new ExpiryReportForm();
            expiryForm.ShowDialog();
        }
    }
}