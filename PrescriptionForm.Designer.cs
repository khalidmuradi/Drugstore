namespace DrugstoreManagement
{
    partial class PrescriptionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datePrescription = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearchDrug = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewAvailableDrugs = new System.Windows.Forms.DataGridView();
            this.btnAddDrug = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewPrescriptionItems = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtBorrowAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableDrugs)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrescriptionItems)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 60);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prescription Details";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.datePrescription);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDoctorName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtCustomerName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 70);
            this.panel2.TabIndex = 1;
            // 
            // datePrescription
            // 
            this.datePrescription.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePrescription.Location = new System.Drawing.Point(780, 35);
            this.datePrescription.Name = "datePrescription";
            this.datePrescription.Size = new System.Drawing.Size(150, 29);
            this.datePrescription.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(776, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date";
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(390, 35);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(350, 29);
            this.txtDoctorName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Doctor Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(15, 35);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(350, 29);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Name";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtSearchDrug);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dataGridViewAvailableDrugs);
            this.panel3.Controls.Add(this.btnAddDrug);
            this.panel3.Location = new System.Drawing.Point(12, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 400);
            this.panel3.TabIndex = 2;
            // 
            // txtSearchDrug
            // 
            this.txtSearchDrug.Location = new System.Drawing.Point(15, 35);
            this.txtSearchDrug.Name = "txtSearchDrug";
            this.txtSearchDrug.Size = new System.Drawing.Size(350, 29);
            this.txtSearchDrug.TabIndex = 3;
            this.txtSearchDrug.TextChanged += new System.EventHandler(this.txtSearchDrug_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Search Drug";
            // 
            // dataGridViewAvailableDrugs
            // 
            this.dataGridViewAvailableDrugs.AllowUserToAddRows = false;
            this.dataGridViewAvailableDrugs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewAvailableDrugs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAvailableDrugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAvailableDrugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailableDrugs.Location = new System.Drawing.Point(15, 70);
            this.dataGridViewAvailableDrugs.MultiSelect = false;
            this.dataGridViewAvailableDrugs.Name = "dataGridViewAvailableDrugs";
            this.dataGridViewAvailableDrugs.ReadOnly = true;
            this.dataGridViewAvailableDrugs.RowHeadersVisible = false;
            this.dataGridViewAvailableDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAvailableDrugs.Size = new System.Drawing.Size(440, 290);
            this.dataGridViewAvailableDrugs.TabIndex = 1;
            // 
            // btnAddDrug
            // 
            this.btnAddDrug.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDrug.ForeColor = System.Drawing.Color.White;
            this.btnAddDrug.Location = new System.Drawing.Point(371, 35);
            this.btnAddDrug.Name = "btnAddDrug";
            this.btnAddDrug.Size = new System.Drawing.Size(84, 29);
            this.btnAddDrug.TabIndex = 0;
            this.btnAddDrug.Text = "Add";
            this.btnAddDrug.UseVisualStyleBackColor = false;
            this.btnAddDrug.Click += new System.EventHandler(this.btnAddDrug_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dataGridViewPrescriptionItems);
            this.panel4.Location = new System.Drawing.Point(488, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 400);
            this.panel4.TabIndex = 3;
            // 
            // dataGridViewPrescriptionItems
            // 
            this.dataGridViewPrescriptionItems.AllowUserToAddRows = false;
            this.dataGridViewPrescriptionItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewPrescriptionItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPrescriptionItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPrescriptionItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPrescriptionItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPrescriptionItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPrescriptionItems.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPrescriptionItems.Name = "dataGridViewPrescriptionItems";
            this.dataGridViewPrescriptionItems.RowHeadersVisible = false;
            this.dataGridViewPrescriptionItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPrescriptionItems.Size = new System.Drawing.Size(482, 398);
            this.dataGridViewPrescriptionItems.TabIndex = 0;
            this.dataGridViewPrescriptionItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewPrescriptionItems_DataError);
            this.dataGridViewPrescriptionItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPrescriptionItems_CellEndEdit);
            this.dataGridViewPrescriptionItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewPrescriptionItems_EditingControlShowing);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnCompleteSale);
            this.panel5.Controls.Add(this.btnClearAll);
            this.panel5.Controls.Add(this.btnRemoveItem);
            this.panel5.Location = new System.Drawing.Point(12, 548);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 70);
            this.panel5.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(369, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCompleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSale.ForeColor = System.Drawing.Color.White;
            this.btnCompleteSale.Location = new System.Drawing.Point(253, 20);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(110, 35);
            this.btnCompleteSale.TabIndex = 2;
            this.btnCompleteSale.Text = "Complete Sale";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new System.EventHandler(this.btnCompleteSale_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.ForeColor = System.Drawing.Color.White;
            this.btnClearAll.Location = new System.Drawing.Point(137, 20);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(110, 35);
            this.btnClearAll.TabIndex = 1;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = false;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(15, 20);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(116, 35);
            this.btnRemoveItem.TabIndex = 0;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtBorrowAmount);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.lblTotalAmount);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.lblTotalDiscount);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.lblSubtotal);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(502, 548);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(470, 70);
            this.panel6.TabIndex = 5;
            // 
            // txtBorrowAmount
            // 
            this.txtBorrowAmount.Location = new System.Drawing.Point(300, 35);
            this.txtBorrowAmount.Name = "txtBorrowAmount";
            this.txtBorrowAmount.Size = new System.Drawing.Size(150, 29);
            this.txtBorrowAmount.TabIndex = 7;
            this.txtBorrowAmount.TextChanged += new System.EventHandler(this.txtBorrowAmount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Borrow Amount";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTotalAmount.Location = new System.Drawing.Point(200, 35);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(90, 29);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "0.00 Afghani";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total Amount";
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.Location = new System.Drawing.Point(100, 35);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(90, 29);
            this.lblTotalDiscount.TabIndex = 3;
            this.lblTotalDiscount.Text = "0.00 Afghani";
            this.lblTotalDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(96, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Total Discount";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(10, 35);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(80, 29);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "0.00 Afghani";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Subtotal";
            // 
            // PrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 631);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prescription Form";
            this.Load += new System.EventHandler(this.PrescriptionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableDrugs)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrescriptionItems)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker datePrescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearchDrug;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewAvailableDrugs;
        private System.Windows.Forms.Button btnAddDrug;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewPrescriptionItems;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCompleteSale;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtBorrowAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label6;
    }
}