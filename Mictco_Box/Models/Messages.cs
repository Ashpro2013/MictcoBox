using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    public static class Messages
    {
        public static void InformationMessage(string strMsg)
        {
            MessageBox.Show(strMsg, Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void WarningMessage(string strMsg)
        {
            MessageBox.Show(strMsg, Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void WarningMessage()
        {
            MessageBox.Show("Please enter full details.", Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        public static void BuiltinMessage()
        {
            MessageBox.Show("This is Built In Account. So this can't be deleted", Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ErrorMessage(string strMsg)
        {
            MessageBox.Show(strMsg, Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void SavedMessage()
        {
            MessageBox.Show("Saved successfully", Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void UpdateMessage()
        {
            MessageBox.Show("Updated successfully", Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void DeleteMessage()
        {
            MessageBox.Show("Deleted successfully", Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ReferenceExistsMessage()
        {
            MessageBox.Show("You can't delete,reference exist", Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ReferenceExistsMessageForUpdate()
        {
            MessageBox.Show("You can't update,reference exist", Properties.Settings.Default.strManufaturer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static bool DeleteConfirmationMessage()
        {
            if (MessageBox.Show("Are you sure to delete ? ", Properties.Settings.Default.strManufaturer, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else { return false; }
        }
        public static bool DialogMessage(string Msg)
        {
            if (MessageBox.Show(Msg, Properties.Settings.Default.strManufaturer, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            else { return false; }
        }
        public static void CloseConfirmationMessage(Form frm)
        {
            if ((MessageBox.Show("Are you sure to exit ? ", Properties.Settings.Default.strManufaturer, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes) { frm.Close(); }
        }
    }
}
