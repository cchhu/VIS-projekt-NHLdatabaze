using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;
namespace XML.Gateway
{
    public class rozhodci_Gateway
    {
        public static XElement Insert(rozhodci rozhodci)
        {
            return new XElement("rozhodci",
            new XAttribute("Idrozhodci", rozhodci.Idrozhodci.ToString()),
            new XAttribute("Jmeno", rozhodci.Jmeno),
            new XAttribute("Prijmeni", rozhodci.Prijmeni),
            new XAttribute("Datnar", rozhodci.Datnar.ToString()),
            new XAttribute("Narodnost", rozhodci.Narodnost),
            new XAttribute("Licence", rozhodci.Licence));
        }

        public static List<XElement> Select()
        {
            return XDocument.Load("Zaloha.XML").Descendants("rozhodci").Descendants("rozhodci").ToList();
        }
    }
}