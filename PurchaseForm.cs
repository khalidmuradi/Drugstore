using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DrugstoreManagement
{
    public partial class PurchaseForm : Form
    {
        private DataTable purchaseItems;
        private int currentSupplierId = 0;

        public PurchaseForm()
        {
            InitializeComponent();
            InitializePurchaseItemsTable();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            datePurchaseDate.Value = DateTime.Today;
            LoadSuppliers();
            LoadAvailableDrugs();
            CalculateTotals();
        }

        private void InitializePurchaseItemsTable()
        {
            purchaseItems = new DataTable();
            purchaseItems.Columns.Add("DrugID", typeof(int));
            purchaseItems.Columns.Add("Name", typeof(string));
            purchaseItems.Columns.Add("Quantity", typeof(int));
            purchaseItems.Columns.Add("PurchasePrice", typeof(decimal));
            purchaseItems.Columns.Add("TotalPrice", typeof(decimal));

            dataGridViewPurchaseItems.DataSource = purchaseItems;
        }

        private void LoadSuppliers()
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = "SELECT SupplierID, Name FROM Suppliers ORDER BY Name";
            DataTable dt = db.ExecuteQuery(query);

            comboSupplier.DataSource = dt;
            comboSupplier.DisplayMember = "Name";
            comboSupplier.ValueMember = "SupplierID";

            // Add event handler for supplier selection change
            comboSupplier.SelectedIndexChanged += ComboSupplier_SelectedIndexChanged;
        }

        private void ComboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSupplier.SelectedValue != null)
            {
                currentSupplierId = Convert.ToInt32(comboSupplier.SelectedValue);
            }
        }

        private void LoadAvailableDrugs(string searchTerm = "")
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT d.DrugID, d.Name, d.Company, d.Dosage, d.SellPrice, i.Stock
                FROM Drugs d
                LEFT JOIN Inventory i ON d.DrugID = i.DrugID";

            var parameters = new List<OleDbParameter>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE d.Name LIKE ? OR d.Company LIKE ?";
                parameters.Add(new OleDbParameter("SearchTerm1", $"%{searchTerm}%"));
                parameters.Add(new OleDbParameter("SearchTerm2", $"%{searchTerm}%"));
            }

            query += " ORDER BY d.Name";

            DataTable dt = db.ExecuteQuery(query, parameters.Count > 0 ? parameters.ToArray() : null);
            dataGridViewAvailableDrugs.DataSource = dt;

            // Hide the DrugID column
            if (dataGridViewAvailableDrugs.Columns.Contains("DrugID"))
            {
                dataGridViewAvailableDrugs.Columns["DrugID"].Visible = false;
            }
        }

        private void txtSearchDrug_TextChanged(object sender, EventArgs e)
        {
            LoadAvailableDrugs(txtSearchDrug.Text.Trim());
        }

        private void dataGridViewPurchaseItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle data errors (e.g., invalid numeric input)
            MessageBox.Show("Please enter a valid numeric value.");
            e.Cancel = true;
        }

        private void dataGridViewPurchaseItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Add numeric validation for quantity and purchase price columns
            if (dataGridViewPurchaseItems.CurrentCell.ColumnIndex ==
                dataGridViewPurchaseItems.Columns["Quantity"].Index ||
                dataGridViewPurchaseItems.CurrentCell.ColumnIndex ==
                dataGridViewPurchaseItems.Columns["PurchasePrice"].Index)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(PurchaseTextBox_KeyPress);
                }
            }
        }

        private void PurchaseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers, decimal point, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void dataGridViewAvailableDrugs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAvailableDrugs.CurrentRow != null)
            {
                // Auto-fill the purchase price with the drug's current purchase price
                decimal purchasePrice = Convert.ToDecimal(dataGridViewAvailableDrugs.CurrentRow.Cells["PurchasePrice"].Value);
                numPurchasePrice.Value = purchasePrice;
            }
        }

        private void btnAddToPurchase_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableDrugs.CurrentRow != null)
            {
                int drugId = Convert.ToInt32(dataGridViewAvailableDrugs.CurrentRow.Cells["DrugID"].Value);
                string name = dataGridViewAvailableDrugs.CurrentRow.Cells["Name"].Value.ToString();
                int quantity = (int)numQuantity.Value;
                decimal purchasePrice = numPurchasePrice.Value;
                decimal totalPrice = quantity * purchasePrice;

                // Check if drug already exists in purchase list
                foreach (DataRow row in purchaseItems.Rows)
                {
                    if (Convert.ToInt32(row["DrugID"]) == drugId)
                    {
                        // Update existing item
                        row["Quantity"] = Convert.ToInt32(row["Quantity"]) + quantity;
                        row["PurchasePrice"] = purchasePrice; // Update to latest price
                        row["TotalPrice"] = Convert.ToDecimal(row["TotalPrice"]) + totalPrice;

                        CalculateTotals();
                        return;
                    }
                }

                // Add new item to purchase list
                DataRow newRow = purchaseItems.NewRow();
                newRow["DrugID"] = drugId;
                newRow["Name"] = name;
                newRow["Quantity"] = quantity;
                newRow["PurchasePrice"] = purchasePrice;
                newRow["TotalPrice"] = totalPrice;
                purchaseItems.Rows.Add(newRow);

                CalculateTotals();
            }
            else
            {
                MessageBox.Show("Please select a drug to add to the purchase.");
            }
        }

        private void dataGridViewPurchaseItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataRow row = purchaseItems.Rows[e.RowIndex];

                // Recalculate total price if quantity or purchase price was edited
                if (dataGridViewPurchaseItems.Columns[e.ColumnIndex].Name == "Quantity" ||
                    dataGridViewPurchaseItems.Columns[e.ColumnIndex].Name == "PurchasePrice")
                {
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal purchasePrice = Convert.ToDecimal(row["PurchasePrice"]);
                    row["TotalPrice"] = quantity * purchasePrice;

                    CalculateTotals();
                }
            }
        }

        private void CalculateTotals()
        {
            int totalQuantity = 0;
            decimal totalAmount = 0;

            foreach (DataRow row in purchaseItems.Rows)
            {
                totalQuantity += Convert.ToInt32(row["Quantity"]);
                totalAmount += Convert.ToDecimal(row["TotalPrice"]);
            }

            lblTotalQuantity.Text = totalQuantity.ToString();
            lblTotalAmount.Text = totalAmount.ToString("N2") + " Afghani";
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPurchaseItems.CurrentRow != null)
            {
                int rowIndex = dataGridViewPurchaseItems.CurrentRow.Index;
                purchaseItems.Rows.RemoveAt(rowIndex);
                CalculateTotals();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all items from the purchase?",
                "Confirm Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                purchaseItems.Rows.Clear();
                CalculateTotals();
            }
        }

        private void btnCompletePurchase_Click(object sender, EventArgs e)
        {
            if (purchaseItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one drug to the purchase.");
                return;
            }

            if (comboSupplier.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a supplier.");
                return;
            }

            if (currentSupplierId == 0)
            {
                MessageBox.Show("Please select a valid supplier.");
                return;
            }

            // Complete the purchase
            if (CompletePurchase())
            {
                MessageBox.Show("Purchase completed successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool CompletePurchase()
        {
            DatabaseHelper db = new DatabaseHelper();
            try
            {
                DateTime purchaseDate = datePurchaseDate.Value;

                // Process each item in the purchase
                foreach (DataRow row in purchaseItems.Rows)
                {
                    int drugId = Convert.ToInt32(row["DrugID"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal purchasePrice = Convert.ToDecimal(row["PurchasePrice"]);
                    decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);

                    // 1. Insert into Purchases table
                    string purchaseQuery = @"
                        INSERT INTO Purchases (DrugID, Quantity, PurchasePrice, PurchaseDate, SupplierID)
                        VALUES (?, ?, ?, ?, ?)";

                    OleDbParameter[] purchaseParams = {
                        new OleDbParameter("DrugID", drugId),
                        new OleDbParameter("Quantity", quantity),
                        new OleDbParameter("PurchasePrice", purchasePrice),
                        new OleDbParameter("PurchaseDate", purchaseDate),
                        new OleDbParameter("SupplierID", currentSupplierId)
                    };

                    db.ExecuteNonQuery(purchaseQuery, purchaseParams);

                    // 2. Update inventory
                    string inventoryQuery = @"UPDATE Inventory SET Stock = Stock + ? WHERE DrugID = ?";
                    OleDbParameter[] inventoryParams = {
                        new OleDbParameter("Quantity", quantity),
                        new OleDbParameter("DrugID", drugId)
                    };
                    db.ExecuteNonQuery(inventoryQuery, inventoryParams);

                    // 3. Update drug purchase price if it's different
                    string checkPriceQuery = "SELECT PurchasePrice FROM Drugs WHERE DrugID = ?";
                    OleDbParameter[] checkPriceParams = {
                        new OleDbParameter("DrugID", drugId)
                    };
                    object currentPrice = db.ExecuteScalar(checkPriceQuery, checkPriceParams);

                    if (currentPrice != null && Convert.ToDecimal(currentPrice) != purchasePrice)
                    {
                        string updatePriceQuery = "UPDATE Drugs SET PurchasePrice = ? WHERE DrugID = ?";
                        OleDbParameter[] updatePriceParams = {
                            new OleDbParameter("PurchasePrice", purchasePrice),
                            new OleDbParameter("DrugID", drugId)
                        };
                        db.ExecuteNonQuery(updatePriceQuery, updatePriceParams);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while completing the purchase: " + ex.Message);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            // Open a form to add a new supplier
            AddSupplierForm supplierForm = new AddSupplierForm();
            if (supplierForm.ShowDialog() == DialogResult.OK)
            {
                // Reload suppliers
                LoadSuppliers();
            }
        }
    }
}