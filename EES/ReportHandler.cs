using EES.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EES
{
    public class ReportHandler
    {
        public void ExportToCSV()
        {
            var report = new FaultLogger().GetReport();

            StringBuilder str = new StringBuilder();
            str.AppendLine("MeasurementID"+"," + "Current" + "," + "FaultID" + "," + "PrimaryLocations" + "," + "SecondaryLocations" + "," + "Timestamp");
            foreach (var item in report)
            {
                str.AppendLine(item.ID + "," + item.Current + "," + item.FaultID + "," + item.PrimaryLocations.Replace(',',' ') + "," + item.SecondaryLocations.Replace(',', ' ') + "," + item.TimeStamp);
            }
            string fileName = "Report_" + "20160503_" + Guid.NewGuid() + ".csv";
            System.IO.File.WriteAllText(@"D:\" + fileName , str.ToString());
        }
    }
}
