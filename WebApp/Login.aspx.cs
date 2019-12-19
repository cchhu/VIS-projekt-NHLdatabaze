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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean test = SpravceServices.loginsuccessfull(TextBox1.Text, TextBox2.Text);
            if (test==true)
            {
                Response.Redirect("~/Players.aspx");
            }
            else
            {
                Response.Write("<script>alert('Uživatel neexistuje');</script>");
                return;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Resetpassword.aspx");
        }
    }
}