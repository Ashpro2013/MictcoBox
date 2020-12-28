using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    public partial class Login : Form
    {
        #region Private Variables
        DBContext db = new DBContext();
        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtStaffName.Text ==string.Empty || txtPassword.Text == string.Empty) { Messages.ErrorMessage("Please enter the details."); return; }
            var staff = db.Staffs.FirstOrDefault(x => x.Name == txtStaffName.Text && x.Password == txtPassword.Text);
            if (staff != null)
            {
                User.iUserId = staff.Id.ToInt32();
                Main frm = new Main();
                frm.Show();
                this.Hide();
            }
            else
            {
                Messages.ErrorMessage("Username or Password you enter is incorrect.");
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnLogin_Click(null, null); }
        }
        #endregion
    }
}
