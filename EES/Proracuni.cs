using EES.DataAccess;
using System.Collections.Generic;

namespace EES
{
    public static class Proracuni
    {
        public static double EkvImpedansa(List<Cvor> listaCvorova, List<Vod> listaVodova, int idCvora)
        {
            double zm = 10;
            double ze = 0;
            
            Vod vod = new Vod();
            Cvor cvor = new Cvor();
            
            while (idCvora != 1)
            {
                vod = listaVodova.Find(x => x.KrajCvor.Equals(idCvora));
                ze += vod.Impedansa;
               
                idCvora = vod.PocCvor;
            }
            return ze + zm;
        }

        public static void FormiranjeParovaStrujaPoDeonicama(List<Cvor> listaCvorova, List<Vod> listaVodova, ref List<ParoviStruja> listaParova)
        {
            foreach (var item in listaParova)
            {
                Vod vod = listaVodova.Find(x => x.id.Equals(item.IndexDeonice));

                #region struja_na_pocetku_deonice
                double ze = EkvImpedansa(listaCvorova, listaVodova, vod.PocCvor);
                item.Ip = vod.Veza.StartVoltage / ze;
                #endregion

                #region struja_na_kraju_deonice
                ze = EkvImpedansa(listaCvorova, listaVodova, vod.KrajCvor);
                item.Ik = vod.Veza.EndVoltage / ze;
                #endregion
            }
        }

        public static List<int> ProcenaMestaKvara(List<ParoviStruja> listaParova, double izmerenaVrednost, ref List<int> listaSekundarnihLokacija)
        {
            List<int> retList = new List<int>();

            foreach (var item in listaParova)
            {
                if (item.Ip >= izmerenaVrednost && item.Ik <= izmerenaVrednost)
                {
                    retList.Add(item.IndexDeonice);
                    continue;
                }
                else if (item.Ip * 0.98 >= izmerenaVrednost && item.Ik * 0.98 <= izmerenaVrednost)
                {
                    listaSekundarnihLokacija.Add(item.IndexDeonice);
                }
                else if (item.Ip * 1.02 >= izmerenaVrednost && item.Ik * 1.02 <= izmerenaVrednost)
                {
                    listaSekundarnihLokacija.Add(item.IndexDeonice);
                }
            }
            new FaultLogger().InsertFaultLog(retList, listaSekundarnihLokacija, izmerenaVrednost);
            return retList;
        }
    }
}
