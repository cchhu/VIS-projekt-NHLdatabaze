using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using DataMapper;
using ServiceLayer;
namespace NHLdatabaze
{
    public partial class PridatHrace : Form
    {
        public PridatHrace()
        {
            InitializeComponent();
            WindowManager.pridathrace = this;
            LoadTymy();

        }
        private void LoadTymy()
        {
            List<tym> tymy = tym_datamapper.Select_vsechny();
            comboBox1.DataSource = tymy;
            comboBox1.DisplayMember = "Nazev";
            comboBox1.ValueMember = "Idtym";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int dr = int.Parse(textBox6.Text);
            int idt = int.Parse(comboBox1.SelectedValue.ToString());
            String jm = textBox1.Text;
            String pr = textBox2.Text;
            String datnar = textBox3.Text;
            String narod = textBox4.Text;
            String pozice = textBox5.Text;
            if (HracServices.addPlayer(dr,idt,jm,pr,narod,pozice,datnar))
            {
                MessageBox.Show("Hrac vlozen");
            }

            else MessageBox.Show("Hrac se stejnym dresem již existuje!");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (WindowManager.menu == null)
            {
                WindowManager.menu = new Menu();
            }

            Hide();

            WindowManager.menu.Show();
        }
    }
}
