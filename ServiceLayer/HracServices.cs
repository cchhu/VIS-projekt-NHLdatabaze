using System;
using System.Collections.Generic;
using System.Text;
using DataMapper;
using BusinessObjects;
namespace ServiceLayer
{
    public class HracServices
    {
        public static Boolean addPlayer(int dr, int idt, String jmeno, String prijmeni, String narod, String pozice, String datnar)
        {
            //select jestli hrac nema ve vybranem tymu dres se stejnym cislem, pokud ne hrac se vlozi
            List<hrac> test = hrac_datamapper.Select_freedres(dr, idt);

            if (test.Count == 0)
            {
                hrac h = new hrac() { Jmeno = jmeno, Prijmeni = prijmeni, Narodnost = narod, Cislodres = dr, Pozice = pozice, Tym_idtym = idt, Datnar = Convert.ToDateTime(datnar) };
                hrac_datamapper.Insert(h);
                return true;
            }

            return false;
        }
    }
}
