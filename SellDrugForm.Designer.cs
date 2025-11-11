namespace DrugstoreManagement
{
    partial class SellDrugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDrugName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.numDiscountPercent = new System.Windows.Forms.NumericUpDown();
            this.numDiscountAmount = new System.Windows.Forms.NumericUpDown();
            this.numBorrowAmount = new System.Windows.Forms.NumericUpDown();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorrowAmount)).BeginInit();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = "Sell Drug";

            // Basic layout
            this.lblDrugName.Location = new System.Drawing.Point(12, 12);
            this.lblDrugName.Name = "lblDrugName";
            this.lblDrugName.Size = new System.Drawing.Size(200, 23);

            this.lblPrice.Location = new System.Drawing.Point(12, 40);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(200, 23);

            this.lblStock.Location = new System.Drawing.Point(12, 68);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(200, 23);

            this.numQuantity.Location = new System.Drawing.Point(12, 100);
            this.numQuantity.Maximum = new decimal(new int[] {10000,0,0,0});
            this.numQuantity.Name = "numQuantity";

            this.numDiscountPercent.Location = new System.Drawing.Point(12, 130);
            this.numDiscountPercent.Name = "numDiscountPercent";

            this.numDiscountAmount.Location = new System.Drawing.Point(12, 160);
            this.numDiscountAmount.Name = "numDiscountAmount";

            this.numBorrowAmount.Location = new System.Drawing.Point(12, 190);
            this.numBorrowAmount.Name = "numBorrowAmount";

            this.lblTotalPrice.Location = new System.Drawing.Point(12, 220);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(200, 23);

            this.btnSell.Location = new System.Drawing.Point(12, 250);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(80, 30);
            this.btnSell.Text = "Sell";

            this.btnCancel.Location = new System.Drawing.Point(100, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Text = "Cancel";

            this.Controls.Add(this.lblDrugName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.numDiscountPercent);
            this.Controls.Add(this.numDiscountAmount);
            this.Controls.Add(this.numBorrowAmount);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnCancel);

            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscountAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBorrowAmount)).EndInit();
        }

        #endregion

        // Designer fields
        private System.Windows.Forms.Label lblDrugName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.NumericUpDown numDiscountPercent;
        private System.Windows.Forms.NumericUpDown numDiscountAmount;
        private System.Windows.Forms.NumericUpDown numBorrowAmount;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnCancel;
    }
}