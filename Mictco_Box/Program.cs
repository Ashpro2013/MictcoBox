using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mictco_Box
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.Connection == string.Empty)
            {
                Application.Run(new DBConfiguration(true));
            }
            else
            {
                DBContext db = new DBContext();
                if (db.Staffs.Count < 1)
                {
                    Application.Run(new StaffView(true));
                }
                else
                {
                    Application.Run(new Login());
                }
            }
        }
    }
}
