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
    public partial class PrescriptionForm : Form
    {
        private DataTable prescriptionItems;

        public PrescriptionForm()
        {
            InitializeComponent();
            InitializePrescriptionItemsTable();
        }

        private void PrescriptionForm_Load(object sender, EventArgs e)
        {
            datePrescription.Value = DateTime.Today;
            LoadAvailableDrugs();
            CalculateTotals();
        }

        private void InitializePrescriptionItemsTable()
        {
            prescriptionItems = new DataTable();
            prescriptionItems.Columns.Add("DrugID", typeof(int));
            prescriptionItems.Columns.Add("Name", typeof(string));
            prescriptionItems.Columns.Add("Quantity", typeof(int));
            prescriptionItems.Columns.Add("SellPrice", typeof(decimal));
            prescriptionItems.Columns.Add("DiscountPercent", typeof(decimal));
            prescriptionItems.Columns.Add("DiscountAmount", typeof(decimal));
            prescriptionItems.Columns.Add("TotalPrice", typeof(decimal));

            dataGridViewPrescriptionItems.DataSource = prescriptionItems;
        }

        private void LoadAvailableDrugs(string searchTerm = "")
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                SELECT d.DrugID, d.Name, d.Company, d.Dosage, d.SellPrice, i.Stock
                FROM Drugs d
                INNER JOIN Inventory i ON d.DrugID = i.DrugID
                WHERE i.Stock > 0";

            var parameters = new List<OleDbParameter>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " AND (d.Name LIKE ? OR d.Company LIKE ?)";
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

        private void dataGridViewPrescriptionItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle data errors (e.g., invalid numeric input)
            MessageBox.Show("Please enter a valid numeric value.");
            e.Cancel = true;
        }

        private void dataGridViewPrescriptionItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Add numeric validation for quantity and discount columns
            if (dataGridViewPrescriptionItems.CurrentCell.ColumnIndex ==
                dataGridViewPrescriptionItems.Columns["Quantity"].Index ||
                dataGridViewPrescriptionItems.CurrentCell.ColumnIndex ==
                dataGridViewPrescriptionItems.Columns["DiscountPercent"].Index)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtSearchDrug_TextChanged(object sender, EventArgs e)
        {
            LoadAvailableDrugs(txtSearchDrug.Text.Trim());
        }

        private void btnAddDrug_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableDrugs.CurrentRow != null)
            {
                int drugId = Convert.ToInt32(dataGridViewAvailableDrugs.CurrentRow.Cells["DrugID"].Value);
                string name = dataGridViewAvailableDrugs.CurrentRow.Cells["Name"].Value.ToString();
                decimal sellPrice = Convert.ToDecimal(dataGridViewAvailableDrugs.CurrentRow.Cells["SellPrice"].Value);
                int stock = Convert.ToInt32(dataGridViewAvailableDrugs.CurrentRow.Cells["Stock"].Value);

                // Check if drug already exists in prescription
                foreach (DataRow row in prescriptionItems.Rows)
                {
                    if (Convert.ToInt32(row["DrugID"]) == drugId)
                    {
                        MessageBox.Show("This drug is already in the prescription. You can adjust the quantity.");
                        return;
                    }
                }

                // Add to prescription items
                DataRow newRow = prescriptionItems.NewRow();
                newRow["DrugID"] = drugId;
                newRow["Name"] = name;
                newRow["Quantity"] = 1;
                newRow["SellPrice"] = sellPrice;
                newRow["DiscountPercent"] = 0;
                newRow["DiscountAmount"] = 0;
                newRow["TotalPrice"] = sellPrice;
                prescriptionItems.Rows.Add(newRow);

                CalculateTotals();
            }
            else
            {
                MessageBox.Show("Please select a drug to add to the prescription.");
            }
        }

        private void dataGridViewPrescriptionItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = prescriptionItems.Rows[e.RowIndex];
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal sellPrice = Convert.ToDecimal(row["SellPrice"]);
                decimal discountPercent = Convert.ToDecimal(row["DiscountPercent"]);

                // Validate quantity
                int drugId = Convert.ToInt32(row["DrugID"]);
                int availableStock = GetAvailableStock(drugId);

                if (quantity > availableStock)
                {
                    MessageBox.Show($"Only {availableStock} units available in stock.");
                    row["Quantity"] = availableStock;
                    quantity = availableStock;
                }

                // Calculate discount amount and total price
                decimal totalWithoutDiscount = quantity * sellPrice;
                decimal discountAmount = totalWithoutDiscount * (discountPercent / 100);
                decimal totalPrice = totalWithoutDiscount - discountAmount;

                row["DiscountAmount"] = discountAmount;
                row["TotalPrice"] = totalPrice;

                CalculateTotals();
            }
        }

        private int GetAvailableStock(int drugId)
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = "SELECT Stock FROM Inventory WHERE DrugID = ?";
            OleDbParameter[] parameters = {
                new OleDbParameter("DrugID", drugId)
            };

            object result = db.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        private void CalculateTotals()
        {
            decimal subtotal = 0;
            decimal totalDiscount = 0;

            foreach (DataRow row in prescriptionItems.Rows)
            {
                subtotal += Convert.ToInt32(row["Quantity"]) * Convert.ToDecimal(row["SellPrice"]);
                totalDiscount += Convert.ToDecimal(row["DiscountAmount"]);
            }

            decimal borrowAmount = 0;
            if (!string.IsNullOrEmpty(txtBorrowAmount.Text))
            {
                decimal.TryParse(txtBorrowAmount.Text, out borrowAmount);
            }

            decimal totalAmount = subtotal - totalDiscount;

            lblSubtotal.Text = subtotal.ToString("N2") + " Afghani";
            lblTotalDiscount.Text = totalDiscount.ToString("N2") + " Afghani";
            lblTotalAmount.Text = totalAmount.ToString("N2") + " Afghani";
        }

        private void txtBorrowAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrescriptionItems.CurrentRow != null)
            {
                int rowIndex = dataGridViewPrescriptionItems.CurrentRow.Index;
                prescriptionItems.Rows.RemoveAt(rowIndex);
                CalculateTotals();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all items from the prescription?",
                "Confirm Clear", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                prescriptionItems.Rows.Clear();
                CalculateTotals();
            }
        }

        private void btnCompleteSale_Click(object sender, EventArgs e)
        {
            if (prescriptionItems.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one drug to the prescription.");
                return;
            }

            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Please enter customer name.");
                return;
            }

            decimal borrowAmount = 0;
            if (!string.IsNullOrEmpty(txtBorrowAmount.Text))
            {
                if (!decimal.TryParse(txtBorrowAmount.Text, out borrowAmount))
                {
                    MessageBox.Show("Please enter a valid borrow amount.");
                    return;
                }
            }

            // Calculate totals
            decimal subtotal = 0;
            decimal totalDiscount = 0;
            decimal totalAmount = 0;

            foreach (DataRow row in prescriptionItems.Rows)
            {
                subtotal += Convert.ToInt32(row["Quantity"]) * Convert.ToDecimal(row["SellPrice"]);
                totalDiscount += Convert.ToDecimal(row["DiscountAmount"]);
            }

            totalAmount = subtotal - totalDiscount;

            if (borrowAmount > totalAmount)
            {
                MessageBox.Show("Borrow amount cannot be greater than total amount.");
                return;
            }

            // Save the prescription and update inventory
            if (SavePrescription(subtotal, totalDiscount, borrowAmount, totalAmount))
            {
                MessageBox.Show("Prescription sale completed successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool SavePrescription(decimal subtotal, decimal totalDiscount, decimal borrowAmount, decimal totalAmount)
        {
            DatabaseHelper db = new DatabaseHelper();
            try
            {
                // 1. Insert into Prescriptions table
                string prescriptionQuery = @"
                    INSERT INTO Prescriptions (CustomerName, DoctorName, PrescriptionDate, TotalAmount)
                    VALUES (?, ?, ?, ?)";

                OleDbParameter[] prescriptionParams = {
                    new OleDbParameter("CustomerName", txtCustomerName.Text.Trim()),
                    new OleDbParameter("DoctorName", txtDoctorName.Text.Trim()),
                    new OleDbParameter("PrescriptionDate", datePrescription.Value),
                    new OleDbParameter("TotalAmount", totalAmount)
                };

                db.ExecuteNonQuery(prescriptionQuery, prescriptionParams);
                // You may want to retrieve the new PrescriptionID if needed

                // 2. Insert into PrescriptionDetails and update inventory
                foreach (DataRow row in prescriptionItems.Rows)
                {
                    int drugId = Convert.ToInt32(row["DrugID"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal sellPrice = Convert.ToDecimal(row["SellPrice"]);
                    decimal discountPercent = Convert.ToDecimal(row["DiscountPercent"]);
                    decimal discountAmount = Convert.ToDecimal(row["DiscountAmount"]);
                    decimal itemTotal = Convert.ToDecimal(row["TotalPrice"]);

                    // Insert into PrescriptionDetails
                    string detailQuery = @"
                        INSERT INTO PrescriptionDetails (PrescriptionID, DrugID, Quantity, SellPrice, 
                            DiscountPercent, DiscountAmount, TotalPrice)
                        VALUES (?, ?, ?, ?, ?, ?, ?)";

                    OleDbParameter[] detailParams = {
                        // You need to get the PrescriptionID if you want to use it here
                        new OleDbParameter("PrescriptionID", 0), // Replace 0 with actual ID if needed
                        new OleDbParameter("DrugID", drugId),
                        new OleDbParameter("Quantity", quantity),
                        new OleDbParameter("SellPrice", sellPrice),
                        new OleDbParameter("DiscountPercent", discountPercent),
                        new OleDbParameter("DiscountAmount", discountAmount),
                        new OleDbParameter("TotalPrice", itemTotal)
                    };

                    db.ExecuteNonQuery(detailQuery, detailParams);

                    // Update inventory
                    string updateInventoryQuery = @"
                        UPDATE Inventory 
                        SET Stock = Stock - ? 
                        WHERE DrugID = ?";

                    OleDbParameter[] inventoryParams = {
                        new OleDbParameter("Quantity", quantity),
                        new OleDbParameter("DrugID", drugId)
                    };

                    db.ExecuteNonQuery(updateInventoryQuery, inventoryParams);

                    // Insert into Sales table
                    string salesQuery = @"
                        INSERT INTO Sales (DrugID, Quantity, SellPrice, DiscountPercent, 
                            DiscountAmount, BorrowAmount, TotalPrice, IsPrescriptionSale, PrescriptionID)
                        VALUES (?, ?, ?, ?, ?, ?, ?, 1, ?)";

                    // Calculate borrow amount proportion for this item
                    decimal itemBorrowAmount = 0;
                    if (borrowAmount > 0)
                    {
                        decimal itemProportion = itemTotal / totalAmount;
                        itemBorrowAmount = borrowAmount * itemProportion;
                    }

                    OleDbParameter[] salesParams = {
                        new OleDbParameter("DrugID", drugId),
                        new OleDbParameter("Quantity", quantity),
                        new OleDbParameter("SellPrice", sellPrice),
                        new OleDbParameter("DiscountPercent", discountPercent),
                        new OleDbParameter("DiscountAmount", discountAmount),
                        new OleDbParameter("BorrowAmount", itemBorrowAmount),
                        new OleDbParameter("TotalPrice", itemTotal),
                        new OleDbParameter("PrescriptionID", 0) // Replace 0 with actual ID if needed
                    };

                    db.ExecuteNonQuery(salesQuery, salesParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the prescription: " + ex.Message);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}