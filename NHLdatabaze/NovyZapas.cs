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
    public partial class NovyZapas : Form
    {
        Database db = new Database();
        public NovyZapas()
        {
            InitializeComponent();

            db.Connect();
            WindowManager.novyzapas = this;
            LoadStadiony();
            LoadTymy();
            LoadRozhodci();
            LoadSpravce();
        }

        private void NovyZapas_Load(object sender, EventArgs e)
        {
            Vynulovani();
        }

        public void Vynulovani()
        {
            dateTimePicker1.Value = DateTime.Now;
            time.Text = "01:00";
            stadionBox.SelectedValue = 1;
            listBox1.SelectedValue = 1;
            listBox2.SelectedValue = 2;
            comboBox1.SelectedValue = 1;
            comboBox2.SelectedValue = 2;
            comboBox3.SelectedValue = 1;
        }
        private void LoadStadiony()
        {
            List<stadion> stadiony = stadion_datamapper.Select_vsechny();
            stadionBox.DataSource = stadiony;
            stadionBox.DisplayMember = "Nazev";
            stadionBox.ValueMember = "Idstadion";
        }

        private void LoadTymy()
        {
            List<tym> tymy = tym_datamapper.Select_vsechny();
            listBox1.DataSource = tymy;
            listBox1.DisplayMember = "Nazev";
            listBox1.ValueMember = "Idtym";
            List<tym> tymy1 = tym_datamapper.Select_vsechny();
            listBox2.DataSource = tymy1;
            listBox2.DisplayMember = "Nazev";
            listBox2.ValueMember = "Idtym";
        }

        private void LoadSpravce()
        {
            List<spravce> spravce = spravce_datamapper.Select_vsechny();
            comboBox3.DataSource = spravce;
            comboBox3.DisplayMember = "Prijmeni";
            comboBox3.ValueMember = "Idspravce";
        }

        private void LoadRozhodci()
        {
            List<rozhodci> rozhodci = rozhodci_datamapper.Select_vsechny();
            comboBox1.DataSource = rozhodci;
            comboBox1.DisplayMember = "Prijmeni";
            comboBox1.ValueMember = "Idrozhodci";
            List<rozhodci> rozhodci1 = rozhodci_datamapper.Select_vsechny();
            comboBox2.DataSource = rozhodci1;
            comboBox2.DisplayMember = "Prijmeni";
            comboBox2.ValueMember = "Idrozhodci";

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (listBox1.GetItemText(listBox1.SelectedItem) != listBox2.GetItemText(listBox2.SelectedItem))
            {
                if (comboBox1.GetItemText(comboBox1.SelectedItem) != comboBox2.GetItemText(comboBox2.SelectedItem))
                {
                    string theDate = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                    
                    String t1;
                    t1 = listBox1.SelectedValue.ToString();
                    String t2;
                    t2 = listBox2.SelectedValue.ToString();
                    String a = dateTimePicker1.Value.ToString("MM-dd-yyyy");
                    String cas = time.Text;

                    int idstad = int.Parse(stadionBox.SelectedValue.ToString());
                    int idroz1 = int.Parse(comboBox1.SelectedValue.ToString());
                    int idroz2 = int.Parse(comboBox2.SelectedValue.ToString());
                    int idsp = int.Parse(comboBox3.SelectedValue.ToString());

                    if (ZapasServices.addMatch(t1, t2, theDate, a, cas, idstad, idroz1, idroz2, idsp))
                    {
                        MessageBox.Show("Zapas vlozen");
                    }
                    else MessageBox.Show("Některý z týmu, již v tento den hraje!");
                }
                else MessageBox.Show("Zkontrolujte údaje!");
            }
            else MessageBox.Show("Zkontrolujte údaje!");
        }

        private void Button1_Click(object sender, EventArgs e)
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


