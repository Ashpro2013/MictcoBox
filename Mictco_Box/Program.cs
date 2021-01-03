using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mictco_Box
{
    static class Program
    {
        static string AuthSecret = "tBwFbHgvRH17fKPMqvQI2AG2QwTU5sH0k3QHrlpS";
        static string BasePath = "https://fireapp-5b98f.firebaseio.com/";
        static string sTable = "Customers/";
        static IFirebaseClient client;
        static IFirebaseConfig config;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(AniHelper.CheckInternet())
            {
                List<MictcoUsers> ipAddress = new List<MictcoUsers>();
                string ip = AniHelper.getCPUID();
                config = new FirebaseConfig
                {
                    AuthSecret = AuthSecret,
                    BasePath = BasePath
                };
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get(sTable);
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        ipAddress.Add(JsonConvert.DeserializeObject<MictcoUsers>(((JProperty)item).Value.ToString()));
                    }
                }
                if(!ipAddress.Any(x=> x.iPAddress==ip))
                {
                    MictcoUsers mictco = new MictcoUsers();
                    mictco.iPAddress =ip;
                    mictco.isUpdatable = false;
                    var entdata = mictco;
                    PushResponse responses = client.Push(sTable, entdata);
                    entdata.Id = responses.Result.name;
                    SetResponse setResponse = client.Set(sTable + entdata.Id, entdata);
                }
                else
                {
                    MictcoUsers mUser = ipAddress.FirstOrDefault(x => x.iPAddress == ip);
                    if(mUser.isUpdatable)
                    {
                        mUser.isUpdatable = false;
                        client = new FireSharp.FirebaseClient(config);
                        SetResponse setResponse = client.Set(sTable + mUser.Id, mUser);
                    }
                }
            }
            if (Properties.Settings.Default.Connection == string.Empty)
            {
                string path = AniHelper.NewDatabaseMethodCE("MictCoDB");
                Properties.Settings.Default.Connection = path;
                Properties.Settings.Default.Save();
            }
            else
            {
                string path = Properties.Settings.Default.Connection.Replace("DataSource=", "");
                if (!File.Exists(path))
                {
                    path = AniHelper.NewDatabaseMethodCE("MictCoDB");
                    Properties.Settings.Default.Connection = path;
                    Properties.Settings.Default.Save();
                }
            }
            DBContext db = new DBContext();
            if(db.Staffs.Count<1)
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
