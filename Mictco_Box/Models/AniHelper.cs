using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;

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
        public static void PanelClearMethod(Panel form)
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
        public static string getCPUID()
        {
            string cpuInfo = "";

            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }
        public static bool CheckInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public static void FillCombo(ComboBox cmb, List<object> obj)
        {
            cmb.ValueMember = "Id";
            cmb.DisplayMember = "Name";
            cmb.DataSource = obj;
        }
    }
}
