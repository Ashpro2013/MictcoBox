using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    public partial class StaffView : Form
    {
        #region Private Variables
        int? iStaffId;
        DBContext db = new DBContext();
        bool isFirstEntry = false;
        #endregion


        #region Constructor
        public StaffView()
        {
            InitializeComponent();
        }
        public StaffView(bool _isFirstEntry)
        {
            isFirstEntry = _isFirstEntry;
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty) { Messages.ErrorMessage("Please fill the details.");return; }
            if(iStaffId ==null || !db.Staffs.Any(x=> x.Id==iStaffId))
            {
                if(isFirstEntry)
                {
                    if (ORMForSDF.InsertToDatabaseObj(new Staff { Id = null, Name = txtName.Text, Password = txtPassword.Text }, "Staff", Properties.Settings.Default.Connection)) 
                    {
                        Login frm = new Login();
                        this.Hide();
                        frm.Show();
                    }
                }
                else
                {
                    if (db.Staffs.FirstOrDefault(x => x.Id == User.iUserId).Name == "Admin")
                    {
                        if (ORMForSDF.InsertToDatabaseObj(new Staff { Id = null, Name = txtName.Text, Password = txtPassword.Text }, "Staff", Properties.Settings.Default.Connection)) { Messages.SavedMessage(); btnClear_Click(null, null); }
                    }
                    else
                    {
                        Messages.ErrorMessage("Only Admin have power to create new User.");
                    }
                }
            }
            else
            {
                if (ORMForSDF.UpdateToDatabaseObj(new Staff { Id = iStaffId, Name = txtName.Text,Password=txtPassword.Text }, "Staff", "Id", iStaffId.toInt32(), Properties.Settings.Default.Connection)) { Messages.UpdateMessage(); btnClear_Click(null, null); };
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            AniHelper.ClearMethod(this);
            iStaffId = null;
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = db.Staffs.ToList();
            txtName.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Messages.DeleteConfirmationMessage() && iStaffId!=null)
            {
                if(db.Transactions.Where(x=> x.FK_Staff == iStaffId).ToList().Count > 0) { Messages.ReferenceExistsMessage(); return; }
                if (ORMForSDF.DeleteFromDatabase("Staff", "Id", iStaffId.toInt32(), Properties.Settings.Default.Connection)) { btnClear_Click(null, null); }
            }
        }
        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Staff staff = db.Staffs.FirstOrDefault(x => x.Name == dgvStaff.CurrentRow.Cells[0].Value.ToString());
                if (staff != null)
                {
                    txtName.Text = staff.Name;
                    txtPassword.Text = staff.Password;
                    iStaffId = staff.Id;  
                    if(staff.Id==User.iUserId)
                    {
                        txtPassword.Enabled = true;
                    }
                    else
                    {
                        txtPassword.Enabled = false;
                    }
                }
            }
        }
        private void StaffView_Load(object sender, EventArgs e)
        {
            if(isFirstEntry)
            {
                txtName.Text = "Admin";
                txtName.Enabled = false;
            }
            dgvStaff.AutoGenerateColumns = false;
            var staff = db.Staffs.FirstOrDefault(x => x.Id == User.iUserId);
            if (staff != null)
            {
                if (staff.Name == "Admin")
                {
                    dgvStaff.DataSource = db.Staffs.ToList();
                }
                else
                {
                    dgvStaff.DataSource = db.Staffs.Where(x => x.Id == User.iUserId).ToList();
                }
            }
            this.ActiveControl = txtName;
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnSave_Click(null, null); }
        }
        #endregion
    }
}