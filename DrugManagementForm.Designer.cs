namespace DrugstoreManagement
{
    partial class DrugManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewDrugs;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddDrug;
        private System.Windows.Forms.Button btnEditDrug;
        private System.Windows.Forms.Button btnSellDrug;
        private System.Windows.Forms.Button btnSellPrescription;
        private System.Windows.Forms.Button btnPurchases;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewDrugs = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddDrug = new System.Windows.Forms.Button();
            this.btnEditDrug = new System.Windows.Forms.Button();
            this.btnSellDrug = new System.Windows.Forms.Button();
            this.btnSellPrescription = new System.Windows.Forms.Button();
            this.btnPurchases = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrugs)).BeginInit();
            this.SuspendLayout();

            // dataGridViewDrugs
            this.dataGridViewDrugs.AllowUserToAddRows = false;
            this.dataGridViewDrugs.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewDrugs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDrugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDrugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrugs.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewDrugs.MultiSelect = false;
            this.dataGridViewDrugs.Name = "dataGridViewDrugs";
            this.dataGridViewDrugs.ReadOnly = true;
            this.dataGridViewDrugs.RowHeadersVisible = false;
            this.dataGridViewDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDrugs.Size = new System.Drawing.Size(960, 400);
            this.dataGridViewDrugs.TabIndex = 0;
            this.dataGridViewDrugs.TabStop = false;

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(60, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";

            // btnAddDrug
            this.btnAddDrug.Location = new System.Drawing.Point(300, 18);
            this.btnAddDrug.Name = "btnAddDrug";
            this.btnAddDrug.Size = new System.Drawing.Size(75, 23);
            this.btnAddDrug.TabIndex = 3;
            this.btnAddDrug.Text = "Add Drug";
            this.btnAddDrug.UseVisualStyleBackColor = true;
            this.btnAddDrug.Click += new System.EventHandler(this.btnAddDrug_Click);

            // btnEditDrug
            this.btnEditDrug.Location = new System.Drawing.Point(381, 18);
            this.btnEditDrug.Name = "btnEditDrug";
            this.btnEditDrug.Size = new System.Drawing.Size(75, 23);
            this.btnEditDrug.TabIndex = 4;
            this.btnEditDrug.Text = "Edit Drug";
            this.btnEditDrug.UseVisualStyleBackColor = true;
            this.btnEditDrug.Click += new System.EventHandler(this.btnEditDrug_Click);

            // btnSellDrug
            this.btnSellDrug.Location = new System.Drawing.Point(462, 18);
            this.btnSellDrug.Name = "btnSellDrug";
            this.btnSellDrug.Size = new System.Drawing.Size(75, 23);
            this.btnSellDrug.TabIndex = 5;
            this.btnSellDrug.Text = "Sell Drug";
            this.btnSellDrug.UseVisualStyleBackColor = true;
            this.btnSellDrug.Click += new System.EventHandler(this.btnSellDrug_Click);

            // btnSellPrescription
            this.btnSellPrescription.Location = new System.Drawing.Point(543, 18);
            this.btnSellPrescription.Name = "btnSellPrescription";
            this.btnSellPrescription.Size = new System.Drawing.Size(100, 23);
            this.btnSellPrescription.TabIndex = 6;
            this.btnSellPrescription.Text = "Sell Prescription";
            this.btnSellPrescription.UseVisualStyleBackColor = true;
            this.btnSellPrescription.Click += new System.EventHandler(this.btnSellPrescription_Click);

            // btnPurchases
            this.btnPurchases.Location = new System.Drawing.Point(649, 18);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new System.Drawing.Size(75, 23);
            this.btnPurchases.TabIndex = 7;
            this.btnPurchases.Text = "Purchases";
            this.btnPurchases.UseVisualStyleBackColor = true;
            this.btnPurchases.Click += new System.EventHandler(this.btnPurchases_Click);

            // btnInventory
            this.btnInventory.Location = new System.Drawing.Point(730, 18);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(75, 23);
            this.btnInventory.TabIndex = 8;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);

            // btnReports
            this.btnReports.Location = new System.Drawing.Point(811, 18);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(75, 23);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // DrugManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnPurchases);
            this.Controls.Add(this.btnSellPrescription);
            this.Controls.Add(this.btnSellDrug);
            this.Controls.Add(this.btnEditDrug);
            this.Controls.Add(this.btnAddDrug);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dataGridViewDrugs);
            this.Name = "DrugManagementForm";
            this.Text = "Drug Management System";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrugs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}