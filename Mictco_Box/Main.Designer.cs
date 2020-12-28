namespace Mictco_Box
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnMasters = new System.Windows.Forms.Button();
            this.btnFirm = new System.Windows.Forms.Button();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabMdi = new System.Windows.Forms.TabControl();
            this.tpDashboard = new System.Windows.Forms.TabPage();
            this.pnlSlots = new System.Windows.Forms.Panel();
            this.pnlNavigation.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.tabMdi.SuspendLayout();
            this.tpDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.AutoScroll = true;
            this.pnlNavigation.BackColor = System.Drawing.Color.Black;
            this.pnlNavigation.Controls.Add(this.btnReports);
            this.pnlNavigation.Controls.Add(this.btnTransaction);
            this.pnlNavigation.Controls.Add(this.btnMasters);
            this.pnlNavigation.Controls.Add(this.btnFirm);
            this.pnlNavigation.Controls.Add(this.btnDashBoard);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigation.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNavigation.Location = new System.Drawing.Point(0, 0);
            this.pnlNavigation.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(225, 749);
            this.pnlNavigation.TabIndex = 4;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Black;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 404);
            this.btnReports.Margin = new System.Windows.Forms.Padding(0);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(225, 40);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.BackColor = System.Drawing.Color.Black;
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnTransaction.Image")));
            this.btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.Location = new System.Drawing.Point(0, 364);
            this.btnTransaction.Margin = new System.Windows.Forms.Padding(0);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(225, 40);
            this.btnTransaction.TabIndex = 5;
            this.btnTransaction.Text = "Staff";
            this.btnTransaction.UseVisualStyleBackColor = false;
            this.btnTransaction.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnMasters
            // 
            this.btnMasters.BackColor = System.Drawing.Color.Black;
            this.btnMasters.FlatAppearance.BorderSize = 0;
            this.btnMasters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnMasters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnMasters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMasters.Image = ((System.Drawing.Image)(resources.GetObject("btnMasters.Image")));
            this.btnMasters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasters.Location = new System.Drawing.Point(0, 324);
            this.btnMasters.Name = "btnMasters";
            this.btnMasters.Size = new System.Drawing.Size(225, 40);
            this.btnMasters.TabIndex = 4;
            this.btnMasters.Text = "Customer";
            this.btnMasters.UseVisualStyleBackColor = false;
            this.btnMasters.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnFirm
            // 
            this.btnFirm.BackColor = System.Drawing.Color.Black;
            this.btnFirm.FlatAppearance.BorderSize = 0;
            this.btnFirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnFirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFirm.Image = ((System.Drawing.Image)(resources.GetObject("btnFirm.Image")));
            this.btnFirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirm.Location = new System.Drawing.Point(0, 284);
            this.btnFirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnFirm.Name = "btnFirm";
            this.btnFirm.Size = new System.Drawing.Size(225, 40);
            this.btnFirm.TabIndex = 2;
            this.btnFirm.Text = "Box";
            this.btnFirm.UseVisualStyleBackColor = false;
            this.btnFirm.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.BackColor = System.Drawing.Color.Black;
            this.btnDashBoard.FlatAppearance.BorderSize = 0;
            this.btnDashBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnDashBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDashBoard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashBoard.Image")));
            this.btnDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashBoard.Location = new System.Drawing.Point(0, 244);
            this.btnDashBoard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(225, 40);
            this.btnDashBoard.TabIndex = 1;
            this.btnDashBoard.Text = "Dashboard";
            this.btnDashBoard.UseVisualStyleBackColor = false;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(48)))), ((int)(((byte)(65)))));
            this.pnlTitle.Controls.Add(this.lblUser);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.btnMinimize);
            this.pnlTitle.Controls.Add(this.btnClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(225, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1095, 49);
            this.pnlTitle.TabIndex = 7;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(191, 19);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(52, 18);
            this.lblUser.TabIndex = 121;
            this.lblUser.Text = "Admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(101, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 121;
            this.label1.Text = "User :";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.btnMinimize.ForeColor = System.Drawing.Color.DarkGray;
            this.btnMinimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMinimize.Location = new System.Drawing.Point(977, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(55, 47);
            this.btnMinimize.TabIndex = 120;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1037, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 47);
            this.btnClose.TabIndex = 119;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabMdi
            // 
            this.tabMdi.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabMdi.Controls.Add(this.tpDashboard);
            this.tabMdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMdi.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMdi.Location = new System.Drawing.Point(225, 49);
            this.tabMdi.Margin = new System.Windows.Forms.Padding(0);
            this.tabMdi.Multiline = true;
            this.tabMdi.Name = "tabMdi";
            this.tabMdi.SelectedIndex = 0;
            this.tabMdi.Size = new System.Drawing.Size(1095, 700);
            this.tabMdi.TabIndex = 8;
            // 
            // tpDashboard
            // 
            this.tpDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tpDashboard.Controls.Add(this.pnlSlots);
            this.tpDashboard.Location = new System.Drawing.Point(4, 4);
            this.tpDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.tpDashboard.Name = "tpDashboard";
            this.tpDashboard.Size = new System.Drawing.Size(1065, 692);
            this.tpDashboard.TabIndex = 0;
            this.tpDashboard.Text = "Dashboard";
            // 
            // pnlSlots
            // 
            this.pnlSlots.BackColor = System.Drawing.Color.White;
            this.pnlSlots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSlots.Location = new System.Drawing.Point(0, 0);
            this.pnlSlots.Name = "pnlSlots";
            this.pnlSlots.Size = new System.Drawing.Size(1065, 692);
            this.pnlSlots.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 749);
            this.Controls.Add(this.tabMdi);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlNavigation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.tabMdi.ResumeLayout(false);
            this.tpDashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnMasters;
        private System.Windows.Forms.Button btnFirm;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabMdi;
        private System.Windows.Forms.TabPage tpDashboard;
        private System.Windows.Forms.Panel pnlSlots;
    }
}