using System;
using System.Collections.Generic;
using System.Text;
using DataMapper;
using BusinessObjects;
namespace ServiceLayer
{
   public class ZapasServices
    {
        public static Boolean addMatch(String t1, String t2, string theDate, String a, String cas, int idstad, int idroz1, int idroz2, int idsp)
        {
            //select jestli jeden z tymu zapas ve stejny den nehraje, pokud ne vlozi zapas
            List<zapas> test = zapas_datamapper.Select_canplay(int.Parse(t1), int.Parse(t2), theDate);
            if (test.Count == 0)
            {
                zapas zp = new zapas()
                {
                    Datum = Convert.ToDateTime(a),
                    Cas = cas,
                    Tym_idtym = int.Parse(t1),
                    Tym_idtym1 = int.Parse(t2),
                    Stadion_idstadion = idstad,
                    Rozhodci_idrozhodci = idroz1,
                    Rozhodci_idrozhodci1 = idroz2,
                    Spravce_idspravce = idsp
                };
                zapas_datamapper.novyzapas(zp.Datum.ToShortDateString(), zp.Cas, zp.Stadion_idstadion, zp.Tym_idtym, zp.Tym_idtym1, zp.Rozhodci_idrozhodci, zp.Rozhodci_idrozhodci1, zp.Spravce_idspravce);
                return true;
            }

            return false;
        }
    }
}
