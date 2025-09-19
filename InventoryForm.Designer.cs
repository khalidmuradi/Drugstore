namespace DrugstoreManagement
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox comboFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.NumericUpDown numAdjustQuantity;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnAdjustStock;
        private System.Windows.Forms.Button btnViewExpiryReport;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblAdjustStock;
        private System.Windows.Forms.DataGridView dataGridViewExpiry;

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
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.numAdjustQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnAdjustStock = new System.Windows.Forms.Button();
            this.btnViewExpiryReport = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblAdjustStock = new System.Windows.Forms.Label();
            this.dataGridViewExpiry = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdjustQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpiry)).BeginInit();
            this.SuspendLayout();
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Items.AddRange(new object[] {
            "All",
            "Low Stock",
            "Out of Stock",
            "Expiring Soon",
            "Expired"});
            this.comboFilter.Location = new System.Drawing.Point(70, 15);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(120, 21);
            this.comboFilter.TabIndex = 0;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(250, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.AllowUserToAddRows = false;
            this.dataGridViewInventory.AllowUserToDeleteRows = false;
            this.dataGridViewInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.ReadOnly = true;
            this.dataGridViewInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInventory.Size = new System.Drawing.Size(760, 350);
            this.dataGridViewInventory.TabIndex = 2;
            this.dataGridViewInventory.SelectionChanged += new System.EventHandler(this.dataGridViewInventory_SelectionChanged);
            // 
            // numAdjustQuantity
            // 
            this.numAdjustQuantity.Location = new System.Drawing.Point(100, 415);
            this.numAdjustQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAdjustQuantity.Name = "numAdjustQuantity";
            this.numAdjustQuantity.Size = new System.Drawing.Size(80, 20);
            this.numAdjustQuantity.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(480, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(570, 12);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(95, 23);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Export to Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(680, 12);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(95, 23);
            this.btnExportPDF.TabIndex = 6;
            this.btnExportPDF.Text = "Export to PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnAdjustStock
            // 
            this.btnAdjustStock.Location = new System.Drawing.Point(200, 415);
            this.btnAdjustStock.Name = "btnAdjustStock";
            this.btnAdjustStock.Size = new System.Drawing.Size(90, 23);
            this.btnAdjustStock.TabIndex = 7;
            this.btnAdjustStock.Text = "Adjust Stock";
            this.btnAdjustStock.UseVisualStyleBackColor = true;
            this.btnAdjustStock.Click += new System.EventHandler(this.btnAdjustStock_Click);
            // 
            // btnViewExpiryReport
            // 
            this.btnViewExpiryReport.Location = new System.Drawing.Point(310, 415);
            this.btnViewExpiryReport.Name = "btnViewExpiryReport";
            this.btnViewExpiryReport.Size = new System.Drawing.Size(120, 23);
            this.btnViewExpiryReport.TabIndex = 8;
            this.btnViewExpiryReport.Text = "View Expiry Report";
            this.btnViewExpiryReport.UseVisualStyleBackColor = true;
            this.btnViewExpiryReport.Click += new System.EventHandler(this.btnViewExpiryReport_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(200, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Search:";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(15, 18);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 10;
            this.lblFilter.Text = "Filter:";
            // 
            // lblAdjustStock
            // 
            this.lblAdjustStock.AutoSize = true;
            this.lblAdjustStock.Location = new System.Drawing.Point(15, 417);
            this.lblAdjustStock.Name = "lblAdjustStock";
            this.lblAdjustStock.Size = new System.Drawing.Size(79, 13);
            this.lblAdjustStock.TabIndex = 11;
            this.lblAdjustStock.Text = "Adjust Quantity:";
            // 
            // dataGridViewExpiry
            // 
            this.dataGridViewExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewExpiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpiry.Location = new System.Drawing.Point(12, 450);
            this.dataGridViewExpiry.Name = "dataGridViewExpiry";
            this.dataGridViewExpiry.Size = new System.Drawing.Size(760, 150);
            this.dataGridViewExpiry.TabIndex = 12;
            this.dataGridViewExpiry.Visible = false;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dataGridViewExpiry);
            this.Controls.Add(this.lblAdjustStock);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnViewExpiryReport);
            this.Controls.Add(this.btnAdjustStock);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.numAdjustQuantity);
            this.Controls.Add(this.dataGridViewInventory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.comboFilter);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "InventoryForm";
            this.Text = "Drugstore Inventory Management";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdjustQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpiry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}