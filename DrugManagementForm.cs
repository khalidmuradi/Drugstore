using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace DrugstoreManagement
{
    public partial class DrugManagementForm : Form
    {
        public DrugManagementForm()
        {
            InitializeComponent();
            LoadDrugs();
        }

        private void LoadDrugs()
        {
            using (DatabaseHelper db = new DatabaseHelper())
            {
                string query = @"
                    SELECT d.DrugID, d.Name, d.Company, d.Dosage, d.Type, d.Barcode, 
                           d.PurchasePrice, d.SellPrice, d.ExpiryDate, i.Stock, i.StockStatus
                    FROM Drugs d
                    LEFT JOIN Inventory i ON d.DrugID = i.DrugID
                    ORDER BY d.Name";

                DataTable dt = db.ExecuteQuery(query);
                dataGridViewDrugs.DataSource = dt;
            }
        }

        private void btnAddDrug_Click(object sender, EventArgs e)
        {
            AddEditDrugForm addForm = new AddEditDrugForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadDrugs(); // Refresh the list
            }
        }

        private void btnEditDrug_Click(object sender, EventArgs e)
        {
            if (dataGridViewDrugs.CurrentRow != null)
            {
                int drugId = Convert.ToInt32(dataGridViewDrugs.CurrentRow.Cells["DrugID"].Value);
                AddEditDrugForm editForm = new AddEditDrugForm(drugId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDrugs(); // Refresh the list
                }
            }
            else
            {
                MessageBox.Show("Please select a drug to edit.");
            }
        }

        private void btnSellDrug_Click(object sender, EventArgs e)
        {
            if (dataGridViewDrugs.CurrentRow != null)
            {
                int drugId = Convert.ToInt32(dataGridViewDrugs.CurrentRow.Cells["DrugID"].Value);
                string drugName = dataGridViewDrugs.CurrentRow.Cells["Name"].Value.ToString();
                decimal sellPrice = Convert.ToDecimal(dataGridViewDrugs.CurrentRow.Cells["SellPrice"].Value);
                int stock = Convert.ToInt32(dataGridViewDrugs.CurrentRow.Cells["Stock"].Value);

                SellDrugForm sellForm = new SellDrugForm(drugId, drugName, sellPrice, stock);
                if (sellForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDrugs(); // Refresh the list
                }
            }
            else
            {
                MessageBox.Show("Please select a drug to sell.");
            }
        }

        private void btnSellPrescription_Click(object sender, EventArgs e)
        {
            PrescriptionForm prescriptionForm = new PrescriptionForm();
            if (prescriptionForm.ShowDialog() == DialogResult.OK)
            {
                LoadDrugs(); // Refresh the drug list to update stock information
            }
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            if (purchaseForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh dashboard to show updated inventory (API not available here) - caller should refresh if needed
                // LoadDashboard();
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();
            inventoryForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            using (DatabaseHelper db = new DatabaseHelper())
            {
                string query = @"
                    SELECT d.DrugID, d.Name, d.Company, d.Dosage, d.Type, d.Barcode, 
                           d.PurchasePrice, d.SellPrice, d.ExpiryDate, i.Stock, i.StockStatus
                    FROM Drugs d
                    LEFT JOIN Inventory i ON d.DrugID = i.DrugID
                    WHERE d.Name LIKE ? OR d.Barcode LIKE ?
                    ORDER BY d.Name";

                OleDbParameter[] parameters = {
                    new OleDbParameter("Search", $"%{searchText}%"),
                    new OleDbParameter("Search", $"%{searchText}%")
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                dataGridViewDrugs.DataSource = dt;
            }
        }
    }
}