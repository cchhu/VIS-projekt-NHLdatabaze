using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceLayer;
namespace WebApp
{
    public partial class Resetpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (SpravceServices.changepassword(TextBox1.Text,TextBox2.Text,TextBox3.Text)==true)
                {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('Chyba');</script>");
                return;
            }
        }
    }
}