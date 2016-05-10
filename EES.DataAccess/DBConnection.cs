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
            _connString = ConfigurationManager.ConnectionStrings["EES"].ConnectionString;
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
