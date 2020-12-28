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
            if (txtStaffName.Text == string.Empty) { Messages.ErrorMessage("Please fill the details.");return; }
            if(iStaffId ==null || !db.Staffs.Any(x=> x.Id==iStaffId))
            {
                if(isFirstEntry)
                {
                    if (ORMForSDF.InsertToDatabaseObj(new Staff { Id = null, Name = txtStaffName.Text, Password = txtPassword.Text }, "Staff", Properties.Settings.Default.Connection)) { Messages.SavedMessage(); btnClear_Click(null, null); }
                }
                else
                {
                    if (db.Staffs.FirstOrDefault(x => x.Id == User.iUserId).Name == "Admin")
                    {
                        if (ORMForSDF.InsertToDatabaseObj(new Staff { Id = null, Name = txtStaffName.Text, Password = txtPassword.Text }, "Staff", Properties.Settings.Default.Connection)) { Messages.SavedMessage(); btnClear_Click(null, null); }
                    }
                    else
                    {
                        Messages.ErrorMessage("Only Admin have power to create new User.");
                    }

                }
            }
            else
            {
                if (ORMForSDF.UpdateToDatabaseObj(new Staff { Id = iStaffId, Name = txtStaffName.Text,Password=txtPassword.Text }, "Staff", "Id", iStaffId.toInt32(), Properties.Settings.Default.Connection)) { Messages.UpdateMessage(); btnClear_Click(null, null); };
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            AniHelper.ClearMethod(this);
            iStaffId = null;
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = db.Staffs.ToList();
            txtStaffName.Focus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Messages.DeleteConfirmationMessage() && iStaffId!=null)
            {
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
                    txtStaffName.Text = staff.Name;
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
                txtStaffName.Text = "Admin";
                txtStaffName.Enabled = false;
            }
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = db.Staffs.ToList();
        }
        #endregion

    }
}