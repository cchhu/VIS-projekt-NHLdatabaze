using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;

namespace XML.Gateway
{
    public class zapas_Gateway
    {
        public static XElement Insert(zapas zapas)
        {
            return new XElement("zapas",
            new XAttribute("Idzapas", zapas.Idzapas.ToString()),
            new XAttribute("Cas", zapas.Cas.ToString()),
            new XAttribute("Datum", zapas.Datum.ToString()),
            new XAttribute("Stadion", zapas.Stadion_idstadion.ToString()),
            new XAttribute("Golydom", zapas.Golydom.ToString()),
            new XAttribute("Golyhos", zapas.Golyhos.ToString()),
            new XAttribute("Tym_idtym", zapas.Tym_idtym.ToString()),
            new XAttribute("Tym_idtym1", zapas.Tym_idtym1.ToString()),
            new XAttribute("Pocetdivaku", zapas.Pocetdivaku.ToString()),
            new XAttribute("Rozhodci_idrozhodci", zapas.Rozhodci_idrozhodci.ToString()),
            new XAttribute("Rozhodci_idrozhodci1", zapas.Rozhodci_idrozhodci1.ToString()),
            new XAttribute("Spravce_idspravce", zapas.Spravce_idspravce.ToString()));
        }

        public static List<XElement> Select()
        {
            return XDocument.Load("Zaloha.XML").Descendants("zapasy").Descendants("zapas").ToList();
        }
    }
}