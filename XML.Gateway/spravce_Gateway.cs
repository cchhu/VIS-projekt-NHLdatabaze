using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;
namespace XML.Gateway
{
    public class spravce_Gateway
    {
        public static XElement Insert(spravce spravce)
        {
            return new XElement("spravce",
            new XAttribute("Idspravce", spravce.Idspravce.ToString()),
            new XAttribute("Jmeno", spravce.Jmeno),
            new XAttribute("Prijmeni", spravce.Prijmeni),
            new XAttribute("Datnar", spravce.Datnar.ToString()),
            new XAttribute("Kontakt", spravce.Kontakt),
            new XAttribute("Heslo", spravce.Heslo));
        }

        public static List<XElement> Select()
        {
            return XDocument.Load("Zaloha.XML").Descendants("spravci").Descendants("spravce").ToList();
        }
    }
}
