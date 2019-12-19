using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMapper;
using ServiceLayer;
namespace NHLdatabaze
{
    public partial class Prihlaseni : Form
    {
        public Prihlaseni()
        {
            InitializeComponent();
            Database db = new Database();
            db.Connect();
            WindowManager.prihlaseni = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string email = login.Text;
            string heslo = pass.Text;

            if(SpravceServices.loginsuccessfull(email,heslo) && WindowManager.menu==null)
            {
                if(SpravceServices.loginsuccessfulladmin(email,heslo))
                {
                    WindowManager.admin = true;
                }

                else { WindowManager.admin = false; }

                WindowManager.menu = new Menu();
                WindowManager.prihlaseni.Hide();
                WindowManager.menu.Show();
            }
     
            else
            {
                MessageBox.Show("Špatně zadané údaje");
            }
        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
