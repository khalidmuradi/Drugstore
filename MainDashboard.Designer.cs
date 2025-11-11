namespace DrugstoreManagement
{
    using System.Windows.Forms;

    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTodaySalesCount;
        private Label lblTodaySalesTotal;
        private Label lblLowStock;
        private Label lblOutOfStock;
        private Label lblExpiryAlert;
        private Button btnRefresh;
        private Button btnDrugManagement;
        private Button btnPurchases;
        private Button btnReports;
        private Button btnLogout;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

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
            this.lblTodaySalesCount = new System.Windows.Forms.Label();
            this.lblTodaySalesTotal = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblOutOfStock = new System.Windows.Forms.Label();
            this.lblExpiryAlert = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDrugManagement = new System.Windows.Forms.Button();
            this.btnPurchases = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTodaySalesCount
            // 
            this.lblTodaySalesCount.AutoSize = true;
            this.lblTodaySalesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTodaySalesCount.Location = new System.Drawing.Point(200, 50);
            this.lblTodaySalesCount.Name = "lblTodaySalesCount";
            this.lblTodaySalesCount.Size = new System.Drawing.Size(17, 17);
            this.lblTodaySalesCount.TabIndex = 0;
            this.lblTodaySalesCount.Text = "0";
            // 
            // lblTodaySalesTotal
            // 
            this.lblTodaySalesTotal.AutoSize = true;
            this.lblTodaySalesTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTodaySalesTotal.Location = new System.Drawing.Point(200, 80);
            this.lblTodaySalesTotal.Name = "lblTodaySalesTotal";
            this.lblTodaySalesTotal.Size = new System.Drawing.Size(82, 17);
            this.lblTodaySalesTotal.TabIndex = 1;
            this.lblTodaySalesTotal.Text = "0 Afghani";
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.Location = new System.Drawing.Point(200, 140);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(17, 17);
            this.lblLowStock.TabIndex = 2;
            this.lblLowStock.Text = "0";
            // 
            // lblOutOfStock
            // 
            this.lblOutOfStock.AutoSize = true;
            this.lblOutOfStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblOutOfStock.Location = new System.Drawing.Point(200, 170);
            this.lblOutOfStock.Name = "lblOutOfStock";
            this.lblOutOfStock.Size = new System.Drawing.Size(17, 17);
            this.lblOutOfStock.TabIndex = 3;
            this.lblOutOfStock.Text = "0";
            // 
            // lblExpiryAlert
            // 
            this.lblExpiryAlert.AutoSize = true;
            this.lblExpiryAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblExpiryAlert.Location = new System.Drawing.Point(200, 200);
            this.lblExpiryAlert.Name = "lblExpiryAlert";
            this.lblExpiryAlert.Size = new System.Drawing.Size(17, 17);
            this.lblExpiryAlert.TabIndex = 4;
            this.lblExpiryAlert.Text = "0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(400, 250);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDrugManagement
            // 
            this.btnDrugManagement.Location = new System.Drawing.Point(50, 300);
            this.btnDrugManagement.Name = "btnDrugManagement";
            this.btnDrugManagement.Size = new System.Drawing.Size(150, 40);
            this.btnDrugManagement.TabIndex = 6;
            this.btnDrugManagement.Text = "Drug Management";
            this.btnDrugManagement.UseVisualStyleBackColor = true;
            this.btnDrugManagement.Click += new System.EventHandler(this.btnDrugManagement_Click);
            // 
            // btnPurchases
            // 
            this.btnPurchases.Location = new System.Drawing.Point(220, 300);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new System.Drawing.Size(150, 40);
            this.btnPurchases.TabIndex = 7;
            this.btnPurchases.Text = "Purchases";
            this.btnPurchases.UseVisualStyleBackColor = true;
            this.btnPurchases.Click += new System.EventHandler(this.btnPurchases_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(390, 300);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(150, 40);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(560, 300);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Today\'s Sales Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Today\'s Sales Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Low Stock Alerts:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Out of Stock Alerts:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Expiry Alerts (30 days):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnPurchases);
            this.Controls.Add(this.btnDrugManagement);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblExpiryAlert);
            this.Controls.Add(this.lblOutOfStock);
            this.Controls.Add(this.lblLowStock);
            this.Controls.Add(this.lblTodaySalesTotal);
            this.Controls.Add(this.lblTodaySalesCount);
            this.Name = "MainForm";
            this.Text = "Drugstore Management System - Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}