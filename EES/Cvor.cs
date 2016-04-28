using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EES
{
    public class Cvor
    {
        private int id;
        private double voltage;
        private List<int> linked;

        public int Id
        {
            get { return id; }
        }

        public double Voltage
        {
            set { this.voltage = value; }
            get { return this.voltage; }
        }

        public Cvor() { }
        public Cvor(int id, double voltage, List<int> linked)
        {
            this.id = id;
            this.voltage = voltage;
            this.linked = linked;
        }
    }
}
