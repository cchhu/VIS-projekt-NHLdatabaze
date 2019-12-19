using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;
namespace XML.Gateway
{
    public class hrac_Gateway
    {
        public static XElement Insert(hrac hrac)
        {
            return new XElement("hrac",
            new XAttribute("Idhrac", hrac.Idhrac.ToString()),
            new XAttribute("Jmeno", hrac.Jmeno),
            new XAttribute("Prijmeni", hrac.Prijmeni),
            new XAttribute("Narodnost", hrac.Narodnost),
            new XAttribute("Datnar", hrac.Datnar.ToString()),
            new XAttribute("Cislodres", hrac.Cislodres.ToString()),
            new XAttribute("Pozice", hrac.Pozice),
            new XAttribute("Tym_idtym", hrac.Tym_idtym.ToString()));
        }

        public static List<XElement> Select()
        {
            return (XDocument.Load(PathOfFiles.cesta).Descendants("Hraci").Descendants("hrac")).ToList();
        }
    }
}