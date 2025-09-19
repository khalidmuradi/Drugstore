namespace DrugstoreManagement
{
    using System.Windows.Forms;

    partial class AddEditDrugForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblDosage = new System.Windows.Forms.Label();
            this.txtDosage = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.numPurchasePrice = new System.Windows.Forms.NumericUpDown();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.numSellPrice = new System.Windows.Forms.NumericUpDown();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.dateExpiry = new System.Windows.Forms.DateTimePicker();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.comboSupplier = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Drug Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(30, 70);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(62, 15);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Company:";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(130, 67);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(250, 23);
            this.txtCompany.TabIndex = 3;
            // 
            // lblDosage
            // 
            this.lblDosage.AutoSize = true;
            this.lblDosage.Location = new System.Drawing.Point(30, 110);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(48, 15);
            this.lblDosage.TabIndex = 4;
            this.lblDosage.Text = "Dosage:";
            // 
            // txtDosage
            // 
            this.txtDosage.Location = new System.Drawing.Point(130, 107);
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.Size = new System.Drawing.Size(250, 23);
            this.txtDosage.TabIndex = 5;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(30, 150);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 15);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "Type:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(130, 147);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(250, 23);
            this.txtType.TabIndex = 7;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(30, 190);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(53, 15);
            this.lblBarcode.TabIndex = 8;
            this.lblBarcode.Text = "Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(130, 187);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(250, 23);
            this.txtBarcode.TabIndex = 9;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(30, 230);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(86, 15);
            this.lblPurchasePrice.TabIndex = 10;
            this.lblPurchasePrice.Text = "Purchase Price:";
            // 
            // numPurchasePrice
            // 
            this.numPurchasePrice.DecimalPlaces = 2;
            this.numPurchasePrice.Location = new System.Drawing.Point(130, 227);
            this.numPurchasePrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPurchasePrice.Name = "numPurchasePrice";
            this.numPurchasePrice.Size = new System.Drawing.Size(120, 23);
            this.numPurchasePrice.TabIndex = 11;
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Location = new System.Drawing.Point(30, 270);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(57, 15);
            this.lblSellPrice.TabIndex = 12;
            this.lblSellPrice.Text = "Sell Price:";
            // 
            // numSellPrice
            // 
            this.numSellPrice.DecimalPlaces = 2;
            this.numSellPrice.Location = new System.Drawing.Point(130, 267);
            this.numSellPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSellPrice.Name = "numSellPrice";
            this.numSellPrice.Size = new System.Drawing.Size(120, 23);
            this.numSellPrice.TabIndex = 13;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(30, 310);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(68, 15);
            this.lblExpiryDate.TabIndex = 14;
            this.lblExpiryDate.Text = "Expiry Date:";
            // 
            // dateExpiry
            // 
            this.dateExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateExpiry.Location = new System.Drawing.Point(130, 307);
            this.dateExpiry.Name = "dateExpiry";
            this.dateExpiry.Size = new System.Drawing.Size(120, 23);
            this.dateExpiry.TabIndex = 15;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(30, 350);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 15);
            this.lblSupplier.TabIndex = 16;
            this.lblSupplier.Text = "Supplier:";
            // 
            // comboSupplier
            // 
            this.comboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSupplier.FormattingEnabled = true;
            this.comboSupplier.Location = new System.Drawing.Point(130, 347);
            this.comboSupplier.Name = "comboSupplier";
            this.comboSupplier.Size = new System.Drawing.Size(250, 23);
            this.comboSupplier.TabIndex = 17;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditDrugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 461);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.dateExpiry);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.numSellPrice);
            this.Controls.Add(this.lblSellPrice);
            this.Controls.Add(this.numPurchasePrice);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtDosage);
            this.Controls.Add(this.lblDosage);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "AddEditDrugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Drug";
            this.Load += new System.EventHandler(this.AddEditDrugForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblCompany;
        private TextBox txtCompany;
        private Label lblDosage;
        private TextBox txtDosage;
        private Label lblType;
        private TextBox txtType;
        private Label lblBarcode;
        private TextBox txtBarcode;
        private Label lblPurchasePrice;
        private NumericUpDown numPurchasePrice;
        private Label lblSellPrice;
        private NumericUpDown numSellPrice;
        private Label lblExpiryDate;
        private DateTimePicker dateExpiry;
        private Label lblSupplier;
        private ComboBox comboSupplier;
        private Button btnSave;
        private Button btnCancel;
    }
}