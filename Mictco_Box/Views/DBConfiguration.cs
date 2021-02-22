using System;
using System.Windows.Forms;

namespace Mictco_Box
{
    public partial class DBConfiguration : Form
    {
        #region private variables
        private bool isFromProgram ;
        #endregion

        #region Constructor
        public DBConfiguration(bool _isFromProgram=false)
        {
            isFromProgram = _isFromProgram;
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Connection = "Server = " + txtServer.Text + "; Database = " + txtDatabase.Text +
               ";User Id = " + txtUserId.Text + "; Password = " + txtPassword.Text;
            Properties.Settings.Default.Save();
            if (isFromProgram)
            {
                StaffView frm = new StaffView();
                frm.Show();
            }
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    TextBox tBox = (TextBox)item;
                    tBox.Clear();
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void DBConfiguration_Load(object sender, EventArgs e)
        {
            string sConnection = Properties.Settings.Default.Connection;
            if (sConnection != string.Empty)
            {
                string[] sCollection = sConnection.Split(new string[] { ";" }, StringSplitOptions.None);
                txtServer.Text = sCollection[0].Replace("Server = ", "");
                txtDatabase.Text = sCollection[1].Replace(" Database = ", "");
                txtUserId.Text = sCollection[2].Replace("User Id = ", "");
                txtPassword.Text = sCollection[3].Replace(" Password = ", "");
            }
        }
        #endregion
    }
}
