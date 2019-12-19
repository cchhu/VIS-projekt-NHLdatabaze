using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using DataMapper;
using ServiceLayer;
namespace WebApp
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<tym> tymy = tym_datamapper.Select_vsechny();
            foreach (tym t in tymy)
            {
                ListItem l = new ListItem(t.Nazev, (t.Idtym).ToString(), true);
                DropDownList1.Items.Add(l);
            }

            List<hrac> hraci = hrac_datamapper.Select_podletym(int.Parse(DropDownList1.SelectedItem.Value));
            foreach(hrac h in hraci)
            {
                ListBox1.Items.Add(h.Jmeno +" "+ h.Prijmeni+" "+h.Pozice+" "+h.Narodnost+" "+h.Cislodres);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ListBox1.Items.Clear();
            List<hrac> hraci = hrac_datamapper.Select_podletym(int.Parse(DropDownList1.SelectedValue.ToString()));
            foreach (hrac h in hraci)
            {
                ListBox1.Items.Add(h.Jmeno + " " + h.Prijmeni + " " + h.Pozice + " " + h.Narodnost + " " + h.Cislodres);
            }

            DropDownList1.Items.Clear();

            List<tym> tymy = tym_datamapper.Select_vsechny();
            foreach (tym t in tymy)
            {
                ListItem l = new ListItem(t.Nazev, (t.Idtym).ToString(), true);
                DropDownList1.Items.Add(l);
            }
        }
    }
}