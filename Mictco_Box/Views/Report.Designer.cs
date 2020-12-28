
namespace Mictco_Box
{
    partial class Report
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
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.col_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Staff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_EmailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
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
            this.col_Customer,
            this.col_Status,
            this.col_Staff,
            this.col_Remarks,
            this.col_EmailId,
            this.col_Company,
            this.col_GST});
            this.dgvReports.Location = new System.Drawing.Point(12, 44);
            this.dgvReports.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.Size = new System.Drawing.Size(1290, 668);
            this.dgvReports.TabIndex = 6;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(264, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(843, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pan Number/Name/Phonenumber:";
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
            // col_Customer
            // 
            this.col_Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_Customer.DataPropertyName = "Name";
            this.col_Customer.FillWeight = 377.4782F;
            this.col_Customer.HeaderText = "Name";
            this.col_Customer.Name = "col_Customer";
            this.col_Customer.ReadOnly = true;
            this.col_Customer.Width = 300;
            // 
            // col_Status
            // 
            this.col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_Status.DataPropertyName = "PanNumber";
            this.col_Status.FillWeight = 9.790575F;
            this.col_Status.HeaderText = "Pan Number";
            this.col_Status.Name = "col_Status";
            this.col_Status.ReadOnly = true;
            this.col_Status.Width = 120;
            // 
            // col_Staff
            // 
            this.col_Staff.DataPropertyName = "City";
            this.col_Staff.FillWeight = 9.790575F;
            this.col_Staff.HeaderText = "City";
            this.col_Staff.Name = "col_Staff";
            this.col_Staff.ReadOnly = true;
            // 
            // col_Remarks
            // 
            this.col_Remarks.DataPropertyName = "PhoneNumber";
            this.col_Remarks.FillWeight = 9.790575F;
            this.col_Remarks.HeaderText = "Phone Number";
            this.col_Remarks.Name = "col_Remarks";
            this.col_Remarks.ReadOnly = true;
            // 
            // col_EmailId
            // 
            this.col_EmailId.DataPropertyName = "EmailId";
            this.col_EmailId.FillWeight = 22.47252F;
            this.col_EmailId.HeaderText = "EmailId";
            this.col_EmailId.Name = "col_EmailId";
            this.col_EmailId.ReadOnly = true;
            // 
            // col_Company
            // 
            this.col_Company.DataPropertyName = "Company";
            this.col_Company.FillWeight = 22.47252F;
            this.col_Company.HeaderText = "Company";
            this.col_Company.Name = "col_Company";
            this.col_Company.ReadOnly = true;
            // 
            // col_GST
            // 
            this.col_GST.DataPropertyName = "GSTNumber";
            this.col_GST.FillWeight = 22.47252F;
            this.col_GST.HeaderText = "GST Number";
            this.col_GST.Name = "col_GST";
            this.col_GST.ReadOnly = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 722);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Staff;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_EmailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GST;
    }
}