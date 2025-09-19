using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DrugstoreManagement
{
    public partial class AddEditDrugForm : Form
    {
        private readonly int drugId = 0;
        private readonly bool isEditMode = false;

        public AddEditDrugForm()
        {
            InitializeComponent();
        }

        public AddEditDrugForm(int id) // Constructor for edit mode
        {
            InitializeComponent();
            drugId = id;
            isEditMode = true;
        }

        private void AddEditDrugForm_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                LoadDrugData();
                this.Text = "Edit Drug";
                btnSave.Text = "Update";
            }
            else
            {
                this.Text = "Add New Drug";
                btnSave.Text = "Save";
            }
        }

        private void LoadDrugData()
        {
            using (DatabaseHelper db = new DatabaseHelper())
            {
                string query = "SELECT * FROM Drugs WHERE DrugID = ?";

                OleDbParameter[] parameters = {
                    new OleDbParameter("DrugID", drugId)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["Name"].ToString();
                    txtCompany.Text = row["Company"].ToString();
                    txtDosage.Text = row["Dosage"].ToString();
                    txtType.Text = row["Type"].ToString();
                    txtBarcode.Text = row["Barcode"].ToString();
                    numPurchasePrice.Value = Convert.ToDecimal(row["PurchasePrice"]);
                    numSellPrice.Value = Convert.ToDecimal(row["SellPrice"]);
                    if (row["ExpiryDate"] != DBNull.Value)
                    {
                        dateExpiry.Value = Convert.ToDateTime(row["ExpiryDate"]);
                    }

                    // Load supplier if exists
                    if (row["SupplierID"] != DBNull.Value)
                    {
                        int supplierId = Convert.ToInt32(row["SupplierID"]);
                        LoadSuppliers(supplierId);
                    }
                    else
                    {
                        LoadSuppliers();
                    }
                }
            }
        }

        private void LoadSuppliers(int selectedSupplierId = 0)
        {
            using (DatabaseHelper db = new DatabaseHelper())
            {
                string query = "SELECT SupplierID, Name FROM Suppliers ORDER BY Name";
                DataTable dt = db.ExecuteQuery(query);

                comboSupplier.DataSource = dt;
                comboSupplier.DisplayMember = "Name";
                comboSupplier.ValueMember = "SupplierID";

                if (selectedSupplierId > 0)
                {
                    comboSupplier.SelectedValue = selectedSupplierId;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveDrug();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter drug name.");
                return false;
            }

            if (numPurchasePrice.Value <= 0)
            {
                MessageBox.Show("Purchase price must be greater than 0.");
                return false;
            }

            if (numSellPrice.Value <= 0)
            {
                MessageBox.Show("Sell price must be greater than 0.");
                return false;
            }

            if (dateExpiry.Value < DateTime.Today)
            {
                MessageBox.Show("Expiry date cannot be in the past.");
                return false;
            }

            return true;
        }

        private void SaveDrug()
        {
            using (DatabaseHelper db = new DatabaseHelper())
            {
                string query;
                OleDbParameter[] parameters;

                if (isEditMode)
                {
                    query = @"
                        UPDATE Drugs 
                        SET Name = ?, Company = ?, Dosage = ?, Type = ?, 
                            Barcode = ?, PurchasePrice = ?, SellPrice = ?, 
                            ExpiryDate = ?, SupplierID = ?
                        WHERE DrugID = ?";

                    parameters = new OleDbParameter[] {
                        new OleDbParameter("Name", txtName.Text.Trim()),
                        new OleDbParameter("Company", txtCompany.Text.Trim()),
                        new OleDbParameter("Dosage", txtDosage.Text.Trim()),
                        new OleDbParameter("Type", txtType.Text.Trim()),
                        new OleDbParameter("Barcode", txtBarcode.Text.Trim()),
                        new OleDbParameter("PurchasePrice", numPurchasePrice.Value),
                        new OleDbParameter("SellPrice", numSellPrice.Value),
                        new OleDbParameter("ExpiryDate", dateExpiry.Value),
                        new OleDbParameter("SupplierID", comboSupplier.SelectedValue == null ? DBNull.Value : comboSupplier.SelectedValue),
                        new OleDbParameter("DrugID", drugId)
                    };
                    db.ExecuteNonQuery(query, parameters);
                }
                else
                {
                    query = @"
                        INSERT INTO Drugs (Name, Company, Dosage, Type, Barcode, PurchasePrice, SellPrice, ExpiryDate, SupplierID)
                        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?);";

                    parameters = new OleDbParameter[] {
                        new OleDbParameter("Name", txtName.Text.Trim()),
                        new OleDbParameter("Company", txtCompany.Text.Trim()),
                        new OleDbParameter("Dosage", txtDosage.Text.Trim()),
                        new OleDbParameter("Type", txtType.Text.Trim()),
                        new OleDbParameter("Barcode", txtBarcode.Text.Trim()),
                        new OleDbParameter("PurchasePrice", numPurchasePrice.Value),
                        new OleDbParameter("SellPrice", numSellPrice.Value),
                        new OleDbParameter("ExpiryDate", dateExpiry.Value),
                        new OleDbParameter("SupplierID", comboSupplier.SelectedValue == null ? DBNull.Value : comboSupplier.SelectedValue)
                    };
                    db.ExecuteNonQuery(query, parameters);

                    // Retrieve the new DrugID
                    string idQuery = "SELECT @@IDENTITY";
                    object result = db.ExecuteScalar(idQuery);
                    int newDrugId = 0;
                    if (result != null && int.TryParse(result.ToString(), out newDrugId))
                    {
                        CreateInventoryEntry(newDrugId);
                    }
                }
            }

            MessageBox.Show("Drug saved successfully.");
        }

        private void CreateInventoryEntry(int drugId)
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = "INSERT INTO Inventory (DrugID, Stock) VALUES (?, 0)";
            OleDbParameter[] parameters = {
                new OleDbParameter("DrugID", drugId)
            };
            db.ExecuteNonQuery(query, parameters);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}