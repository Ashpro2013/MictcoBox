using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Reflection;
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
                if (item is MictcoUsercontrol.MictcoTextBox)
                {
                    item.Text = string.Empty;
                }
            }
        }
        public static void CopyData(Object source, Object target)
        {
            Type sourceType = source.GetType();
            Type targetType = target.GetType();
            PropertyInfo[] srcProps = sourceType.GetProperties();
            foreach (PropertyInfo srcProp in srcProps)
            {
                PropertyInfo targetProperty = targetType.GetProperty(srcProp.Name);
                if (!srcProp.CanRead)
                {
                    continue;
                }
                if (targetProperty == null)
                {
                    continue;
                }
                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }
                if ((targetProperty.GetSetMethod().Attributes & MethodAttributes.Static) != 0)
                {
                    continue;
                }
                if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                {
                    continue;
                }
                // Passed all tests, lets set the value
                try
                {
                    targetProperty.SetValue(target, srcProp.GetValue(source, null), null);
                }
                catch (Exception) { }
            }
        }
        public static List<T> CopyListData<T>(List<object> listSource)
        {
            List<T> dsList = new List<T>();
            foreach (object x in listSource)
            {
                T y = Activator.CreateInstance<T>();
                CopyData(x, y);
                dsList.Add(y);
            }
            return dsList;
        }
        public static string  NewDatabaseMethodCE(string Company)
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
                return strConnection;
            }
            catch (Exception )
            {
                return strConnection;
            }
        }

    }
}
