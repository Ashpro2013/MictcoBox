namespace Mictco_Box
{
    partial class BoxView
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new MictcoUsercontrol.MictcoTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.dgBox = new System.Windows.Forms.DataGridView();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSlotCount = new MictcoUsercontrol.MictcoTextBox();
            this.dgSlot = new System.Windows.Forms.DataGridView();
            this.col_Slot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSlot)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Number of Slots";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CreatedBy :";
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.EnterColor = System.Drawing.Color.LightPink;
            this.txtName.LeaveColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(98, 25);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(306, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // cmbStaff
            // 
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(98, 58);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(306, 21);
            this.cmbStaff.TabIndex = 3;
            // 
            // dgBox
            // 
            this.dgBox.AllowUserToAddRows = false;
            this.dgBox.AllowUserToDeleteRows = false;
            this.dgBox.BackgroundColor = System.Drawing.Color.White;
            this.dgBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Name});
            this.dgBox.Location = new System.Drawing.Point(421, 25);
            this.dgBox.Name = "dgBox";
            this.dgBox.ReadOnly = true;
            this.dgBox.RowHeadersVisible = false;
            this.dgBox.Size = new System.Drawing.Size(363, 293);
            this.dgBox.TabIndex = 7;
            this.dgBox.TabStop = false;
            this.dgBox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellContentClick);
            // 
            // col_Name
            // 
            this.col_Name.DataPropertyName = "Name";
            this.col_Name.HeaderText = "Box Name";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            this.col_Name.Width = 360;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(306, 288);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(205, 288);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(100, 288);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSlotCount
            // 
            this.txtSlotCount.EnterColor = System.Drawing.Color.LightPink;
            this.txtSlotCount.LeaveColor = System.Drawing.Color.White;
            this.txtSlotCount.Location = new System.Drawing.Point(98, 88);
            this.txtSlotCount.Name = "txtSlotCount";
            this.txtSlotCount.Size = new System.Drawing.Size(308, 20);
            this.txtSlotCount.TabIndex = 5;
            this.txtSlotCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSlotCount_KeyDown);
            this.txtSlotCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSlotCount_KeyPress);
            this.txtSlotCount.Validated += new System.EventHandler(this.txtSlotCount_Validated);
            // 
            // dgSlot
            // 
            this.dgSlot.AllowUserToAddRows = false;
            this.dgSlot.AllowUserToDeleteRows = false;
            this.dgSlot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSlot.BackgroundColor = System.Drawing.Color.White;
            this.dgSlot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgSlot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSlot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Slot});
            this.dgSlot.Location = new System.Drawing.Point(100, 117);
            this.dgSlot.Name = "dgSlot";
            this.dgSlot.ReadOnly = true;
            this.dgSlot.RowHeadersVisible = false;
            this.dgSlot.Size = new System.Drawing.Size(304, 163);
            this.dgSlot.TabIndex = 11;
            // 
            // col_Slot
            // 
            this.col_Slot.DataPropertyName = "Name";
            this.col_Slot.HeaderText = "Slot";
            this.col_Slot.Name = "col_Slot";
            this.col_Slot.ReadOnly = true;
            // 
            // BoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 329);
            this.Controls.Add(this.dgSlot);
            this.Controls.Add(this.txtSlotCount);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgBox);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BoxView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Box";
            this.Load += new System.EventHandler(this.BoxView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MictcoUsercontrol.MictcoTextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStaff;
        private System.Windows.Forms.DataGridView dgBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private MictcoUsercontrol.MictcoTextBox txtSlotCount;
        private System.Windows.Forms.DataGridView dgSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Slot;
    }
}