using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    public class AniHelper
    {
        public static string GetDate(DateTime dateTime)
        {
            try
            {
                return dateTime.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void ClearMethod(Form form)
        {
            foreach (Control item in form.Controls)
            {
                if (item is DevExpress.XtraEditors.TextEdit)
                {
                    item.Text = string.Empty;
                }
            }
        }
        public static void NewDatabaseMethodCE(string Company)
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Data\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str = path + Company + ".sdf";
            if (File.Exists(str))
            {
                File.Delete(str);
            }
            string strConnection = "DataSource=" + str;
            SqlCeEngine en = new SqlCeEngine(strConnection);
            en.CreateDatabase();
            string query = string.Empty;
            try
            {
                FileInfo file = new FileInfo(Path.GetDirectoryName(Application.ExecutablePath) + "\\MasterScript.sql");
                if (!file.Exists)
                {
                    System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        file = new FileInfo(dlg.FileName);
                    }
                }
                string script = file.OpenText().ReadToEnd();
                //script = script.Replace("PRIMARY KEY", "");
                string[] scripts = script.Split(new string[] { "GO" }, StringSplitOptions.None);
                using (SqlCeConnection cecon = new SqlCeConnection(strConnection))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand())
                    {
                        cmd.Connection = cecon;
                        cecon.Open();
                        foreach (string item in scripts)
                        {
                            query = item;
                            cmd.CommandText = item;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("New Company Created Successfully.", Properties.Settings.Default.strManufaturer);
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.Message + " + " + query);
            }
        }

    }
}
