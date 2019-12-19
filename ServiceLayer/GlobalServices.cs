using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;
using DataMapper;
using XML.Gateway;

namespace ServiceLayer
{
    public class GlobalServices
    {
        public static Boolean exporttoXML()
        {
            XDocument xDoc = new XDocument();
            XElement xRoot = new XElement("Database");

            List<hrac> hraci = hrac_datamapper.Select_vsechny();
            XElement xHraci = new XElement("Hraci");

            foreach (var hr in hraci)
            {
                xHraci.Add(hrac_Gateway.Insert(hr));
            }
            /*
                        List<rozhodci> rozhodci = rozhodci_datamapper.Select_vsechny();
                        XElement xRozhodci = new XElement("Rozhodci");

                        foreach (var roz in rozhodci)
                        {
                            xRozhodci.Add(rozhodci_Gateway.Insert(roz));
                        }

                        List<spravce> spravci = spravce_datamapper.Select_vsechny();
                        XElement xSpravci = new XElement("Spravci");

                        foreach (var sp in spravci)
                        {
                            xSpravci.Add(spravce_Gateway.Insert(sp));
                        }

                        List<stadion> stadiony = stadion_datamapper.Select_vsechny();
                        XElement xStadiony = new XElement("Stadiony");

                        foreach (var st in stadiony)
                        {
                            xStadiony.Add(stadion_Gateway.Insert(st));
                        }

                        List<tym> tymy = tym_datamapper.Select_vsechny();
                        XElement xTymy = new XElement("Tymy");

                        foreach (var t in tymy)
                        {
                            xTymy.Add(tym_Gateway.Insert(t));
                        }

                        List<zapas> zapasy = zapas_datamapper.Select_vsechny();
                        XElement xZapasy = new XElement("Zapasy");

                        foreach (var zap in zapasy)
                        {
                            xZapasy.Add(zapas_Gateway.Insert(zap));
                        }
                        */
            xRoot.Add(xHraci);
            /*            xRoot.Add(xRozhodci);
                        xRoot.Add(xSpravci);
                        xRoot.Add(xStadiony);
                        xRoot.Add(xTymy);
                        xRoot.Add(xZapasy);*/

            xDoc.Add(xRoot);

            using (StreamWriter sw = new StreamWriter(XML.Gateway.PathOfFiles.cesta))
            {
                sw.Write(xDoc.ToString());
            }
            return true;
        }

         public static Boolean importfromXML()
        {
            hrac_datamapper.DeleteAll();

            foreach (var element in hrac_Gateway.Select())
            {
                hrac hr = new hrac();
                hr.Idhrac = int.Parse(element.Attribute("Idhrac").Value);
                hr.Jmeno = element.Attribute("Jmeno").Value;
                hr.Prijmeni = element.Attribute("Prijmeni").Value;
                hr.Narodnost = element.Attribute("Narodnost").Value;
                hr.Datnar = DateTime.Parse(element.Attribute("Datnar").Value);
                hr.Cislodres = int.Parse(element.Attribute("Cislodres").Value);
                hr.Pozice = element.Attribute("Pozice").Value;
                hr.Tym_idtym = int.Parse(element.Attribute("Tym_idtym").Value);
                hrac_datamapper.Insert(hr);
            }

            return true;
        }
    }
}
