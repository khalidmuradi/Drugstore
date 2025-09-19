namespace DrugstoreManagement
{
    using System.Windows.Forms;

    partial class AddSupplierForm
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
            // Minimal controls required by code-behind
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.txtAgentPhoneNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = "Add Supplier";

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 15);
            this.lblName.Text = "Name:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(100, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);

            // txtPhoneNo
            this.txtPhoneNo.Location = new System.Drawing.Point(100, 40);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(250, 23);

            // txtAgentName
            this.txtAgentName.Location = new System.Drawing.Point(100, 71);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.Size = new System.Drawing.Size(250, 23);

            // txtAgentPhoneNo
            this.txtAgentPhoneNo.Location = new System.Drawing.Point(100, 102);
            this.txtAgentPhoneNo.Name = "txtAgentPhoneNo";
            this.txtAgentPhoneNo.Size = new System.Drawing.Size(250, 23);

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(100, 133);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 60);
            this.txtAddress.Multiline = true;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(100, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(190, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            // Add controls
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.txtAgentName);
            this.Controls.Add(this.txtAgentPhoneNo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
        }

        #endregion

        // Designer fields
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.TextBox txtAgentPhoneNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}