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
using System.Xml.Linq;

namespace DrugstoreManagement
{
    public partial class AddSupplierForm : Form
    {
        public AddSupplierForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveSupplier();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter supplier name.");
                return false;
            }

            return true;
        }

        private void SaveSupplier()
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = @"
                INSERT INTO Suppliers (Name, PhoneNo, AgentName, AgentPhoneNo, Address)
                VALUES (?, ?, ?, ?, ?)";

            OleDbParameter[] parameters = {
                new OleDbParameter("Name", txtName.Text.Trim()),
                new OleDbParameter("PhoneNo", txtPhoneNo.Text.Trim()),
                new OleDbParameter("AgentName", txtAgentName.Text.Trim()),
                new OleDbParameter("AgentPhoneNo", txtAgentPhoneNo.Text.Trim()),
                new OleDbParameter("Address", txtAddress.Text.Trim())
            };

            db.ExecuteNonQuery(query, parameters);
            MessageBox.Show("Supplier added successfully.");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}