using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intelektika1
{
    public partial class Form1 : Form
    {
        bool galimaKeistiReiksme = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        /*
        private void reiksmiuEventas(object sender, EventArgs e)
        {
            if(galimaKeistiReiksme)
            {
                ((TextBox)sender).Text = "bandymas";
                galimaKeistiReiksme = false;
            }
            else
            {
                galimaKeistiReiksme = true;
            }
        }
        */
        /*
        private void koeficientuEventas(object sender, EventArgs e)
        {
            if (galimaKeistiReiksme)
            {

                galimaKeistiReiksme = false;
            }
            else
            {
                galimaKeistiReiksme = true;
            }
        }
        */
        private int tikrintReiksme(TextBox textbox,string reiksme)
        {
            int skaicius;
            if(!int.TryParse(reiksme,out skaicius))
            {
                throw new Exception("Įvestas neskaičius!");
                textbox.Text = "0";
            }
            return skaicius;
        }

        private int tikrintKoeficienta(TextBox textbox,string reiksme)
        {
            int skaicius;
            if (!int.TryParse(reiksme, out skaicius))
            {
                throw new Exception("Įvestas neskaičius!");
                textbox.Text = "0";
            }
            if(skaicius>100)
            {
                throw new Exception("Įvestas skaičius viršija 100!");
                textbox.Text = "0";
            }
            else if(skaicius<0)
            {
                throw new Exception("Įvestas skaičius žemiau 0!");
                textbox.Text = "0";
            }
            else
            {
                return skaicius;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DuomenuParuosimas.Klases.Generate Generate = new DuomenuParuosimas.Klases.Generate();
            var Properciai = Generate.GetAllProperties(@"C:\Users\Rolandas\Desktop\Planai-su-diagrama.xlsx"); //Savo patha reiks nurodyti(galima bus padaryt kad pasirenki excelio faila) 
            var Uzpildytas = Generate.Uzpildymas(@"C:\Users\Rolandas\Desktop\Planai-su-diagrama.xlsx", Properciai);
            MessageBox.Show("Čia ne messageboxas kurio tu ieškai");
            MessageBox.Show("WTF kas per gitas");
        }
    }
}
