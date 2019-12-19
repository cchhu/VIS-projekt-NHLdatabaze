using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;
namespace XML.Gateway
{
    public class stadion_Gateway
    {
        public static XElement Insert(stadion stadion)
        {
            return new XElement("stadion",
            new XAttribute("Idstadion", stadion.Idstadion.ToString()),
            new XAttribute("Nazev", stadion.Nazev),
            new XAttribute("Kapacita", stadion.Kapacita.ToString()),
            new XAttribute("Mesto", stadion.Mesto),
            new XAttribute("Ulice", stadion.Ulice),
            new XAttribute("Psc", stadion.Psc.ToString()));
        }

        public static List<XElement> Select()
        {
            return XDocument.Load("Zaloha.XML").Descendants("stadiony").Descendants("stadion").ToList();
        }
    }
}
