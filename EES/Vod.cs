namespace EES
{
    public class Povezanost
    {
        private Cvor pocetak = new Cvor();
        private Cvor kraj = new Cvor();

        public Cvor Pocetak
        {
            set { this.pocetak = value; }
            get { return pocetak; }
        }

        public Cvor Kraj
        {
            set { this.kraj = value; }
            get { return kraj; }    
        }

        public double EndVoltage
        {
            get { return this.kraj.Voltage; }
        }

        public double StartVoltage
        {
            get { return this.pocetak.Voltage; }
        }
    }

    public class Vod
    {
        public int id;
        public Povezanost veza;
        public double impedansa;

        public double Impedansa
        {
            get { return this.impedansa; }
        }

        public double Id
        {
            get { return id; }
        }

        public int PocCvor
        {
            get { return veza.Pocetak.Id; }
        }

        public int KrajCvor
        {
            get { return veza.Kraj.Id; }
        }

        public Povezanost Veza
        {
            get { return this.veza; }
        }

        public Vod(int id, double impedansa, Cvor pocetak, Cvor kraj)
        {
            this.id = id;
            this.impedansa = impedansa;
            veza = new Povezanost();
            this.veza.Pocetak = pocetak;
            this.veza.Kraj = kraj;
        }

        public Vod() { }

    }
}
