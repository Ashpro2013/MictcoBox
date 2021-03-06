﻿namespace Mictco_Box
{
    partial class TransactionView
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
            this.txtSearch = new MictcoUsercontrol.MictcoTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.col_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SlotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Staff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(236, 14);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(467, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtPanNo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pan Number/Name/Company:";
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_SL,
            this.col_Date,
            this.col_Customer,
            this.col_SlotName,
            this.col_Status,
            this.col_Staff,
            this.col_Remarks});
            this.dgvReports.Location = new System.Drawing.Point(7, 48);
            this.dgvReports.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.Size = new System.Drawing.Size(707, 368);
            this.dgvReports.TabIndex = 3;
            // 
            // col_SL
            // 
            this.col_SL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_SL.DataPropertyName = "SL";
            this.col_SL.HeaderText = "SL";
            this.col_SL.Name = "col_SL";
            this.col_SL.ReadOnly = true;
            this.col_SL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_SL.Width = 50;
            // 
            // col_Date
            // 
            this.col_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_Date.DataPropertyName = "Date";
            this.col_Date.FillWeight = 382.1656F;
            this.col_Date.HeaderText = "Date";
            this.col_Date.Name = "col_Date";
            this.col_Date.ReadOnly = true;
            this.col_Date.Width = 130;
            // 
            // col_Customer
            // 
            this.col_Customer.DataPropertyName = "CustomerName";
            this.col_Customer.FillWeight = 43.56688F;
            this.col_Customer.HeaderText = "Customer";
            this.col_Customer.Name = "col_Customer";
            this.col_Customer.ReadOnly = true;
            // 
            // col_SlotName
            // 
            this.col_SlotName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_SlotName.DataPropertyName = "SlotName";
            this.col_SlotName.FillWeight = 43.56688F;
            this.col_SlotName.HeaderText = "Slot";
            this.col_SlotName.Name = "col_SlotName";
            this.col_SlotName.ReadOnly = true;
            this.col_SlotName.Width = 50;
            // 
            // col_Status
            // 
            this.col_Status.DataPropertyName = "Status";
            this.col_Status.FillWeight = 43.56688F;
            this.col_Status.HeaderText = "Status";
            this.col_Status.Name = "col_Status";
            this.col_Status.ReadOnly = true;
            // 
            // col_Staff
            // 
            this.col_Staff.DataPropertyName = "StaffName";
            this.col_Staff.FillWeight = 43.56688F;
            this.col_Staff.HeaderText = "Staff";
            this.col_Staff.Name = "col_Staff";
            this.col_Staff.ReadOnly = true;
            // 
            // col_Remarks
            // 
            this.col_Remarks.DataPropertyName = "Remarks";
            this.col_Remarks.FillWeight = 43.56688F;
            this.col_Remarks.HeaderText = "Remarks";
            this.col_Remarks.Name = "col_Remarks";
            this.col_Remarks.ReadOnly = true;
            // 
            // TransactionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 424);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TransactionView";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.TransactionView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MictcoUsercontrol.MictcoTextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SlotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Staff;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Remarks;
    }
}