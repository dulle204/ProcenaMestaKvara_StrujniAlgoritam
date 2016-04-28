using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EES;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    { 
        
        public Cvor[] cvor = new Cvor[6];
        public Vod[] vod = new Vod[5];                        

        public List<Vod> ListaVodova = new List<Vod>();
        public List<Cvor> ListaCvorova = new List<Cvor>();

        public ParoviStruja parStruja;
        public List<ParoviStruja> listaParova = new List<ParoviStruja>();
        public List<int> listaPotencijalnihLokacijaKvara = new List<int>();
        

        public Form1()
        {
            InitializeComponent();

            label4.Font = new Font("Ariel", 14);
            this.label5.Font = new Font("Ariel", 14);

            cvor[0] = new Cvor(1, 11000, new List<int> { 2 });
            cvor[1] = new Cvor(2, 10900, new List<int> { 1, 3 });
            cvor[2] = new Cvor(3, 10800, new List<int> { 2 });
            cvor[3] = new Cvor(4, 10800, new List<int> { 2, 5, 6 });
            cvor[4] = new Cvor(5, 10700, new List<int> { 4 });
            cvor[5] = new Cvor(6, 10680, new List<int> { 4 });

            vod[0] = new Vod(12, 5.56, cvor[0], cvor[1]);
            vod[1] = new Vod(23, 5.56, cvor[1], cvor[2]);
            vod[2] = new Vod(24, 5.56, cvor[1], cvor[3]);
            vod[3] = new Vod(45, 5.71, cvor[3], cvor[4]);
            vod[4] = new Vod(46, 5.81, cvor[3], cvor[5]);
       
            for (int i = 0; i < cvor.Length; i++)
            {
                ListaCvorova.Add(cvor[i]);
            }

            for (int i = 0; i < vod.Length; i++)
            {
                ListaVodova.Add(vod[i]);
            }

            foreach (var item in ListaVodova)
            {
                listaParova.Add(new ParoviStruja(item.id));
            }
        }

        public void PristupiKontroli(Action method)
        {
            this.Invoke(method);
        }        

        public void Prikaz(List<int> list, List<int> list2)
        {
            PristupiKontroli(() =>
                {
                    label12.Text = "";
                    label23.Text = "";
                    label24.Text = "";
                    label45.Text = "";
                    label46.Text = "";

                    if (list.Count <= 0)
                    {
                    }
                    else
                    {
                        foreach (var item in list)
                        {
                            switch (item)
                            {
                                case 12:
                                    label12.Text = "!!";
                                    label12.Font = new Font("Ariel", 14);
                                    label12.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 23:
                                    label23.Text = "!!";
                                    label23.Font = new Font("Ariel", 14);
                                    label23.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 24:
                                    label24.Text = "!!";
                                    label24.Font = new Font("Ariel", 14);
                                    label24.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 45:
                                    label45.Text = "!!";
                                    label45.Font = new Font("Ariel", 14);
                                    label45.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 46:
                                    label46.Text = "!!";
                                    label46.Font = new Font("Ariel", 14);
                                    label46.ForeColor = System.Drawing.Color.Red;
                                    break;
                            }
                        }

                        foreach (var item in list2)
                        {
                            switch (item)
                            {
                                case 12:
                                    label12.Text = "!";
                                    label12.Font = new Font("Ariel", 14);
                                    label12.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 23:
                                    label23.Text = "!";
                                    label23.Font = new Font("Ariel", 14);
                                    label23.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 24:
                                    label24.Text = "!";
                                    label24.Font = new Font("Ariel", 14);
                                    label24.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 45:
                                    label45.Text = "!";
                                    label45.Font = new Font("Ariel", 14);
                                    label45.ForeColor = System.Drawing.Color.Red;
                                    break;
                                case 46:
                                    label46.Text = "!";
                                    label46.Font = new Font("Ariel", 14);
                                    label46.ForeColor = System.Drawing.Color.Red;
                                    break;
                            }
                        }
                    }
                });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double merenaVrednost = double.Parse(izmerenaVrednost.Text);           

            Proracuni.FormiranjeParovaStrujaPoDeonicama(ListaCvorova, ListaVodova, ref listaParova);

            List<int> listaSekundarnihLokacijaKvara = new List<int>();
            listaPotencijalnihLokacijaKvara = Proracuni.ProcenaMestaKvara(listaParova, merenaVrednost, ref listaSekundarnihLokacijaKvara);

            Prikaz(listaPotencijalnihLokacijaKvara, listaSekundarnihLokacijaKvara);            
        }            
    }
}
