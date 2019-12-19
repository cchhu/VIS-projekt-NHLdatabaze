using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;
namespace XML.Gateway
{
    public class zamestnanec_Gateway
    {
        public static XElement Insert(zamestnanec zamestnanec)
        {
            return new XElement("zamestnanec",
            new XAttribute("Idzamestnanec", zamestnanec.Idzamestnanec.ToString()),
            new XAttribute("Jmeno", zamestnanec.Jmeno),
            new XAttribute("Prijmeni", zamestnanec.Prijmeni),
            new XAttribute("Datnar", zamestnanec.Datnar.ToString()),
            new XAttribute("Prace", zamestnanec.Prace),
            new XAttribute("Tym_idtym", zamestnanec.Tym_idtym.ToString()));
        }

        public static List<XElement> Select()
        {
            return XDocument.Load("Zaloha.XML").Descendants("zamestnanci").Descendants("zamestnanec").ToList();
        }
    }
}