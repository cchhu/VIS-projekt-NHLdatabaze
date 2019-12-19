using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BusinessObjects;
namespace XML.Gateway
{
    public class tym_Gateway
    {
        public static XElement Insert(tym tym)
        {
            return new XElement("tym",
            new XAttribute("Idtym", tym.Idtym.ToString()),
            new XAttribute("Nazev", tym.Nazev),
            new XAttribute("Rokvzniku", tym.Rokvzniku));
        }

        public static List<XElement> Select()
        {
            return XDocument.Load(PathOfFiles.cesta).Descendants("tymy").Descendants("tym").ToList();
        }
    }
}