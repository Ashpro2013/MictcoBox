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
        int? iStaffId;
        DBContext db = new DBContext();
        public StaffView()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStaffName.Text == string.Empty) { Messages.ErrorMessage("Please fill the details.");return; }
            if(iStaffId ==null || !db.Staffs.Any(x=> x.Id==iStaffId))
            {
                if (ORMForSDF.InsertToDatabaseObj(new Staff { Id = null, Name = txtStaffName.Text,Password= txtPassword.Text }, "Staff", Properties.Settings.Default.Connection)) { Messages.SavedMessage(); btnClear_Click(null, null); }
            }
            else
            {
                if (ORMForSDF.UpdateToDatabaseObj(new Staff { Id = iStaffId, Name = txtStaffName.Text,Password=txtPassword.Text }, "Staff", "Id", iStaffId.toInt32(), Properties.Settings.Default.Connection)) { Messages.UpdateMessage(); btnClear_Click(null, null); };
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStaffName.Text = string.Empty;
            iStaffId = null;
            txtStaffName.Focus();
            StaffView_Load(null, null);
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
                    iStaffId = staff.Id;                    
                }

            }
        }

        private void StaffView_Load(object sender, EventArgs e)
        {
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.DataSource = db.Staffs.ToList();
        }
    }
}