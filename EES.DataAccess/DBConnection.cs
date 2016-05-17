using System.Configuration;

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
