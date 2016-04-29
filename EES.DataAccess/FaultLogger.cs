using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EES.DataAccess
{
    public class FaultLogger
    {
        public void InsertFaultLog(List<int> PrimaryLocations, List<int> SecondaryLocations)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString)) 
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"InsertFaultlog";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter primaryLocations = new SqlParameter("PrimaryLocations", System.Data.SqlDbType.VarChar, 100);
                    foreach (var item in PrimaryLocations)
                    {
                        primaryLocations.Value += item.ToString() + ",";
                    }

                    SqlParameter secondaryLocations = new SqlParameter("SecondaryLocations", System.Data.SqlDbType.VarChar, 100);
                    foreach (var item in SecondaryLocations)
                    {
                        secondaryLocations.Value += item.ToString() + ",";
                    }

                    SqlParameter timeStamp = new SqlParameter("TimeStamp", System.Data.SqlDbType.DateTime);
                    timeStamp.Value = DateTime.Now;

                    cmd.Parameters.Add(primaryLocations);
                    cmd.Parameters.Add(secondaryLocations);
                    cmd.Parameters.Add(timeStamp);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
