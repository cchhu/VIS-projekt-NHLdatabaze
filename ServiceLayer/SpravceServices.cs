using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using DataMapper;
namespace ServiceLayer
{
   public class SpravceServices
    {
        public static Boolean loginsuccessfull(string email, string heslo)
        {
            spravce sp = spravce_datamapper.Select_vsechny().FirstOrDefault(spravce => spravce.Kontakt == email && heslo == spravce.Heslo);

            if (sp == null)
            {
                return false;
            }

            return true;
        }

        public static Boolean loginsuccessfulladmin(string email, string heslo)
        {
            spravce sp = spravce_datamapper.Select_vsechny().FirstOrDefault(spravce => spravce.Kontakt == email && heslo == spravce.Heslo);
            if (sp.Administrator == "Y")
            {
                return true;
            }
            return false;
        }

        public static Boolean changepassword(String email, String a, String b)
        {
            //zmeni heslo spravce
            spravce sp = spravce_datamapper.Select_byemail(email).FirstOrDefault();
            if (sp != null)
            {
                if (a == b)
                {
                    sp.Heslo = a;
                    spravce_datamapper.Update(sp);
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

    }
}
