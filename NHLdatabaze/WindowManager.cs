using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMapper;
using BusinessObjects;

namespace NHLdatabaze
{
    public class WindowManager
    {        
        public static Prihlaseni prihlaseni { get; set; }
        public static Menu menu { get; set; }
        public static Boolean admin { get; set; }
        public static NovyZapas novyzapas { get; set; }
        public static PridatHrace pridathrace { get; set; }
    }
}
