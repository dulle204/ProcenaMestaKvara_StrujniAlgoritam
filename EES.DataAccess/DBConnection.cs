using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace EES.DataAccess
{
    public class DBConnection
    {
        private readonly string _connString = null;
        private static object _syncRoot = new object();

        private DBConnection()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            _connString = "Data Source=DIVANISEVIC;Initial Catalog=EES;Integrated Security=True";//ConfigurationSettings.AppSettings["EES"].ToString();
#pragma warning restore CS0618 // Type or member is obsolete
        }

        private static DBConnection _instance = null;

        public static string GetConnectionString
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        _instance = new DBConnection();
                    }
                }
                return _instance._connString;
            }
        }
    }
}
