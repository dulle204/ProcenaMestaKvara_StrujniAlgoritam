using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EES
{
    public class ParoviStruja
    {
        private double ip;
        private double ik;
        private int indexDeonice;

        public double Ip
        {
            get { return this.ip; }
            set { this.ip = value; }
        }

        public double Ik
        {
            get { return this.ik; }
            set { this.ik = value; }
        }

        public int IndexDeonice
        {
            get { return this.indexDeonice; }
            set { this.indexDeonice = value; }
        }

        public ParoviStruja(int indexDeonice)
        {
            this.indexDeonice = indexDeonice;
            this.ip = 0;
            this.ik = 0;
        }
    }
}
