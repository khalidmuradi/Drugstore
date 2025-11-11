namespace DrugstoreManagement
{
    using System.Windows.Forms;

    partial class PurchaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Designer fields
        private ComboBox comboSupplier;
        private DataGridView dataGridViewAvailableDrugs;
        private DataGridView dataGridViewPurchaseItems;
        private TextBox txtSearchDrug;
        private NumericUpDown numQuantity;
        private NumericUpDown numPurchasePrice;
        private Label lblTotalQuantity;
        private Label lblTotalAmount;
        private DateTimePicker datePurchaseDate;

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
            this.comboSupplier = new ComboBox();
            this.txtSearchDrug = new TextBox();
            this.dataGridViewAvailableDrugs = new DataGridView();
            this.dataGridViewPurchaseItems = new DataGridView();
            this.numQuantity = new NumericUpDown();
            this.numPurchasePrice = new NumericUpDown();
            this.lblTotalQuantity = new Label();
            this.lblTotalAmount = new Label();
            this.datePurchaseDate = new DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableDrugs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();

            this.SuspendLayout();

            // 
            // comboSupplier
            // 
            this.comboSupplier.Location = new System.Drawing.Point(12, 12);
            this.comboSupplier.Name = "comboSupplier";
            this.comboSupplier.Size = new System.Drawing.Size(300, 23);

            // 
            // datePurchaseDate
            // 
            this.datePurchaseDate.Location = new System.Drawing.Point(320, 12);
            this.datePurchaseDate.Name = "datePurchaseDate";
            this.datePurchaseDate.Size = new System.Drawing.Size(120, 23);

            // 
            // txtSearchDrug
            // 
            this.txtSearchDrug.Location = new System.Drawing.Point(12, 50);
            this.txtSearchDrug.Name = "txtSearchDrug";
            this.txtSearchDrug.Size = new System.Drawing.Size(300, 23);

            // 
            // dataGridViewAvailableDrugs
            // 
            this.dataGridViewAvailableDrugs.Location = new System.Drawing.Point(12, 80);
            this.dataGridViewAvailableDrugs.Name = "dataGridViewAvailableDrugs";
            this.dataGridViewAvailableDrugs.Size = new System.Drawing.Size(760, 200);

            // 
            // dataGridViewPurchaseItems
            // 
            this.dataGridViewPurchaseItems.Location = new System.Drawing.Point(12, 290);
            this.dataGridViewPurchaseItems.Name = "dataGridViewPurchaseItems";
            this.dataGridViewPurchaseItems.Size = new System.Drawing.Size(760, 200);

            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(12, 500);
            this.numQuantity.Name = "numQuantity";

            // 
            // numPurchasePrice
            // 
            this.numPurchasePrice.Location = new System.Drawing.Point(100, 500);
            this.numPurchasePrice.Name = "numPurchasePrice";

            // 
            // lblTotalQuantity
            // 
            this.lblTotalQuantity.Location = new System.Drawing.Point(12, 530);
            this.lblTotalQuantity.Name = "lblTotalQuantity";

            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Location = new System.Drawing.Point(100, 530);
            this.lblTotalAmount.Name = "lblTotalAmount";

            // 
            // PurchaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Purchase";

            this.Controls.Add(this.comboSupplier);
            this.Controls.Add(this.datePurchaseDate);
            this.Controls.Add(this.txtSearchDrug);
            this.Controls.Add(this.dataGridViewAvailableDrugs);
            this.Controls.Add(this.dataGridViewPurchaseItems);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.numPurchasePrice);
            this.Controls.Add(this.lblTotalQuantity);
            this.Controls.Add(this.lblTotalAmount);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableDrugs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}