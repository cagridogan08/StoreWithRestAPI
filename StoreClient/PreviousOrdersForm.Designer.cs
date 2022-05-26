namespace StoreClient
{
    partial class PreviousOrdersForm
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
            this.dgvPreOrders = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblFirstLastName = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lstOrderDetail = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpOrderDetails = new System.Windows.Forms.GroupBox();
            this.lblPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpOrderDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPreOrders
            // 
            this.dgvPreOrders.AllowUserToAddRows = false;
            this.dgvPreOrders.AllowUserToDeleteRows = false;
            this.dgvPreOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreOrders.Location = new System.Drawing.Point(12, 178);
            this.dgvPreOrders.Name = "dgvPreOrders";
            this.dgvPreOrders.RowTemplate.Height = 25;
            this.dgvPreOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreOrders.Size = new System.Drawing.Size(695, 212);
            this.dgvPreOrders.TabIndex = 3;
            this.dgvPreOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreOrders_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblPhone);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.lblFirstLastName);
            this.groupBox1.Controls.Add(this.lblCustomerID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 160);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Info";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(38, 105);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(38, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "label4";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(38, 129);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 15);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "label4";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(38, 75);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 15);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "label3";
            // 
            // lblFirstLastName
            // 
            this.lblFirstLastName.AutoSize = true;
            this.lblFirstLastName.Location = new System.Drawing.Point(38, 47);
            this.lblFirstLastName.Name = "lblFirstLastName";
            this.lblFirstLastName.Size = new System.Drawing.Size(38, 15);
            this.lblFirstLastName.TabIndex = 1;
            this.lblFirstLastName.Text = "label2";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Location = new System.Drawing.Point(38, 19);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(38, 15);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "label1";
            // 
            // lstOrderDetail
            // 
            this.lstOrderDetail.HideSelection = false;
            this.lstOrderDetail.Location = new System.Drawing.Point(0, 22);
            this.lstOrderDetail.MultiSelect = false;
            this.lstOrderDetail.Name = "lstOrderDetail";
            this.lstOrderDetail.Size = new System.Drawing.Size(397, 138);
            this.lstOrderDetail.TabIndex = 4;
            this.lstOrderDetail.UseCompatibleStateImageBehavior = false;
            this.lstOrderDetail.Visible = false;
            // 
            // grpOrderDetails
            // 
            this.grpOrderDetails.Controls.Add(this.lstOrderDetail);
            this.grpOrderDetails.Location = new System.Drawing.Point(240, 12);
            this.grpOrderDetails.Name = "grpOrderDetails";
            this.grpOrderDetails.Size = new System.Drawing.Size(397, 160);
            this.grpOrderDetails.TabIndex = 5;
            this.grpOrderDetails.TabStop = false;
            this.grpOrderDetails.Text = "Order Details";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(669, 87);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(38, 15);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "label2";
            // 
            // PreviousOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 393);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.grpOrderDetails);
            this.Controls.Add(this.dgvPreOrders);
            this.Controls.Add(this.groupBox1);
            this.Name = "PreviousOrdersForm";
            this.Text = "PreviousOrdersForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviousOrdersForm_FormClosing);
            this.Load += new System.EventHandler(this.PreviousOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpOrderDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFirstLastName;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.DataGridView dgvPreOrders;
        private System.Windows.Forms.ListView lstOrderDetail;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox grpOrderDetails;
        private System.Windows.Forms.Label lblPrice;
    }
}