using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class zamestnanec
    {
        public int Idzamestnanec { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime Datnar { get; set; }
        public string Prace { get; set; }
        public int Tym_idtym { get; set; }
    }
}
