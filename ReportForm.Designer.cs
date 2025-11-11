namespace DrugstoreManagement
{
    partial class ReportForm
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
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.comboReportType = new System.Windows.Forms.ComboBox();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.lblSummary = new System.Windows.Forms.Label();

            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(10, 10);
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(130, 10);
            // 
            // comboReportType
            // 
            this.comboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReportType.Location = new System.Drawing.Point(260, 10);
            this.comboReportType.Size = new System.Drawing.Size(200, 23);
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Location = new System.Drawing.Point(10, 40);
            this.groupBoxFilters.Size = new System.Drawing.Size(760, 120);
            this.groupBoxFilters.Text = "Filters";
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.Location = new System.Drawing.Point(10, 170);
            this.dataGridViewReport.Size = new System.Drawing.Size(760, 250);
            this.dataGridViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // lblSummary
            // 
            this.lblSummary.Location = new System.Drawing.Point(10, 430);
            this.lblSummary.Size = new System.Drawing.Size(400, 20);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.dataGridViewReport);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.comboReportType);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Text = "ReportForm";
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.ComboBox comboReportType;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.DataGridView dataGridViewReport;
        private System.Windows.Forms.Label lblSummary;
    }
}