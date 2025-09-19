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
    public partial class SellDrugForm : Form
    {
        private int drugId;
        private string drugName;
        private decimal sellPrice;
        private int currentStock;

        public SellDrugForm(int id, string name, decimal price, int stock)
        {
            InitializeComponent();
            drugId = id;
            drugName = name;
            sellPrice = price;
            currentStock = stock;
        }

        private void SellDrugForm_Load(object sender, EventArgs e)
        {
            lblDrugName.Text = drugName;
            lblPrice.Text = sellPrice.ToString("N2") + " Afghani";
            lblStock.Text = currentStock.ToString();
            numQuantity.Maximum = currentStock;
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void numDiscountPercent_ValueChanged(object sender, EventArgs e)
        {
            // If discount percent is changed, calculate discount amount
            decimal totalWithoutDiscount = (decimal)numQuantity.Value * sellPrice;
            decimal discountAmount = totalWithoutDiscount * (numDiscountPercent.Value / 100);
            numDiscountAmount.Value = discountAmount;
            CalculateTotal();
        }

        private void numDiscountAmount_ValueChanged(object sender, EventArgs e)
        {
            // If discount amount is changed, calculate discount percent
            decimal totalWithoutDiscount = (decimal)numQuantity.Value * sellPrice;
            decimal discountPercent = totalWithoutDiscount > 0 ? (numDiscountAmount.Value / totalWithoutDiscount) * 100 : 0;
            numDiscountPercent.Value = (decimal)discountPercent;
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal quantity = (decimal)numQuantity.Value;
            decimal totalWithoutDiscount = quantity * sellPrice;
            decimal discount = numDiscountAmount.Value;
            decimal borrow = numBorrowAmount.Value;
            decimal total = totalWithoutDiscount - discount;

            lblTotalPrice.Text = total.ToString("N2") + " Afghani";
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            decimal totalWithoutDiscount = (decimal)numQuantity.Value * sellPrice;
            if (numDiscountAmount.Value > totalWithoutDiscount)
            {
                MessageBox.Show("Discount cannot be greater than total price.");
                return;
            }

            if (numBorrowAmount.Value > (totalWithoutDiscount - numDiscountAmount.Value))
            {
                MessageBox.Show("Borrow amount cannot be greater than net total.");
                return;
            }

            SellDrug();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SellDrug()
        {
            int quantity = (int)numQuantity.Value;
            decimal discountPercent = numDiscountPercent.Value;
            decimal discountAmount = numDiscountAmount.Value;
            decimal borrowAmount = numBorrowAmount.Value;
            decimal totalPrice = (quantity * sellPrice) - discountAmount;

            DatabaseHelper db = new DatabaseHelper();

            // Update inventory
            string updateInventoryQuery = @"
                UPDATE Inventory 
                SET Stock = Stock - ? 
                WHERE DrugID = ?";
            OleDbParameter[] updateParams = {
                new OleDbParameter("Quantity", quantity),
                new OleDbParameter("DrugID", drugId)
            };
            db.ExecuteNonQuery(updateInventoryQuery, updateParams);

            // Insert sales record
            string insertSalesQuery = @"
                INSERT INTO Sales (DrugID, Quantity, SellPrice, DiscountPercent, DiscountAmount, BorrowAmount, TotalPrice)
                VALUES (?, ?, ?, ?, ?, ?, ?)";
            OleDbParameter[] salesParams = {
                new OleDbParameter("DrugID", drugId),
                new OleDbParameter("Quantity", quantity),
                new OleDbParameter("SellPrice", sellPrice),
                new OleDbParameter("DiscountPercent", discountPercent),
                new OleDbParameter("DiscountAmount", discountAmount),
                new OleDbParameter("BorrowAmount", borrowAmount),
                new OleDbParameter("TotalPrice", totalPrice)
            };
            db.ExecuteNonQuery(insertSalesQuery, salesParams);

            MessageBox.Show("Sale completed successfully.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}