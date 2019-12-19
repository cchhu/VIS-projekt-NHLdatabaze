using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class spravce
    {
        public int Idspravce { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime Datnar { get; set; }
        public string Kontakt { get; set; }

        public string Heslo { get; set; }

        public string Administrator { get; set; }
    }
}
