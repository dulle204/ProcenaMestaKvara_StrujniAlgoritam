using System;
using System.Data.SqlClient;
using System.Numerics;

namespace EES.DataAccess
{
    
    public class FaultEventModel
    {
        public int ID { get; set; }

        public decimal Current { get; set; }

        public int FaultID { get; set; }

        public string PrimaryLocations { get; set; }

        public string SecondaryLocations { get; set; }

        public DateTime TimeStamp { get; set; }


        public void Load(SqlDataReader reader)
        {
            ID = Convert.ToInt32(reader["MeasurementID"].ToString());
            Current = Convert.ToDecimal(reader["Current"].ToString());
            FaultID = Convert.ToInt32(reader["FaultID"].ToString());
            PrimaryLocations = reader["PrimaryLocations"].ToString();
            SecondaryLocations = reader["SecondaryLocations"].ToString();
            TimeStamp = Convert.ToDateTime(reader["TimeStamp"].ToString());
        }
    }
}