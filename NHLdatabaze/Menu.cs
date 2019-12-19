using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BusinessObjects;
using DataMapper;
using XML.Gateway;
using ServiceLayer;
namespace NHLdatabaze
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Database db = new Database();
            db.Connect();
            WindowManager.menu = this;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (WindowManager.admin == true)
            {
                loggedas.Text = "Přihlášen jako: Administrátor";
            }
            if (WindowManager.admin == false)
            {
                loggedas.Text = "Přihlášen jako: Správce";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(WindowManager.novyzapas==null)
            {
                WindowManager.novyzapas = new NovyZapas();
            }
            WindowManager.menu.Hide();
            WindowManager.novyzapas.Show();
        }

        private void BtnZaloha_Click(object sender, EventArgs e)
        {
            if (GlobalServices.exporttoXML())
            {
                MessageBox.Show("Zalohovano!");
            }
        }

        private void BtnObnovit_Click(object sender, EventArgs e)
        {
            if (GlobalServices.importfromXML())
            {
                MessageBox.Show("Obnoveno!");
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (WindowManager.pridathrace == null)
            {
                WindowManager.pridathrace = new PridatHrace();
            }
            WindowManager.menu.Hide();
            WindowManager.pridathrace.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
    }
}
