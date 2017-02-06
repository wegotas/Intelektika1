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
        double smsKiekis;
        double minKiekis;
        double MBKiekis;
        double smsKiekisUzsn;
        double minKiekisUzsn;
        double MBKiekisUzsn;
        double ApytiksleKaina;
        private List<DuomenuParuosimas.Klases.Reiksmes> OLEGUI = new List<DuomenuParuosimas.Klases.Reiksmes>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                smsKiekis = viduriuoti(textBox1.Text, textBox28.Text, textBox42.Text);
                minKiekis = viduriuoti(textBox4.Text, textBox26.Text, textBox40.Text);
                MBKiekis = viduriuoti(textBox6.Text, textBox24.Text, textBox38.Text);
                smsKiekisUzsn = viduriuoti(textBox8.Text, textBox22.Text, textBox36.Text);
                minKiekisUzsn = viduriuoti(textBox10.Text, textBox20.Text, textBox34.Text);
                MBKiekisUzsn = viduriuoti(textBox12.Text, textBox18.Text, textBox32.Text);
                ApytiksleKaina = viduriuoti(textBox14.Text, textBox16.Text, textBox30.Text);
                RastiAtstumus();
                MessageBox.Show("Programos pabaiga");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private double viduriuoti(string a, string b, string c)
        {
            int x, y, z;
            int.TryParse(a, out x);
            int.TryParse(b, out y);
            int.TryParse(c, out z);
            return (x + y + z) / 3;
        }
        private int tikrintReiksme(TextBox textbox, string reiksme)
        {
            int skaicius;
            if (!int.TryParse(reiksme, out skaicius))
            {
                throw new Exception("Įvestas neskaičius!");
                textbox.Text = "0";
            }
            return skaicius;
        }

        private int tikrintKoeficienta(TextBox textbox, string reiksme)
        {
            int skaicius;
            if (!int.TryParse(reiksme, out skaicius))
            {
                throw new Exception("Įvestas neskaičius!");
                textbox.Text = "0";
            }
            if (skaicius > 100)
            {
                throw new Exception("Įvestas skaičius viršija 100!");
                textbox.Text = "0";
            }
            else if (skaicius < 0)
            {
                throw new Exception("Įvestas skaičius žemiau 0!");
                textbox.Text = "0";
            }
            else
            {
                return skaicius;
            }
        }

        public void RastiAtstumus()
        {
            foreach (var val in OLEGUI)
            {
                /*double zmz = double.Parse(l[1]); // Plano sms
                double mim = double.Parse(l[2]);// Plano min
                double nb = double.Parse(l[3]);// Plano mb
                double zmzu = double.Parse(l[4]);// Plano smsu
                double mimu = double.Parse(l[5]);// Plano minu
                double nbu = double.Parse(l[6]);// Plano mbu*/
                var smsVisur = Convert.ToDouble( val.Properties[2].PropercioReiksme);
                var miniLt = Convert.ToDouble(val.Properties[3].PropercioReiksme);
                var duomenuKiekis = Convert.ToDouble(val.Properties[4].PropercioReiksme);
                var smsUzsienis = Convert.ToDouble(val.Properties[5].PropercioReiksme);
                var MinUzsienis = Convert.ToDouble(val.Properties[6].PropercioReiksme);
                var mbUzsienis = Convert.ToDouble(val.Properties[7].PropercioReiksme);
                var kaina = Convert.ToDouble(val.Properties[8].PropercioReiksme);
                var atstumas = Math.Sqrt(
                    Math.Pow((smsKiekis-smsUzsienis),2)+Math.Pow((minKiekis-miniLt),2)+Math.Pow(((MBKiekis - duomenuKiekis)),2)+
                    Math.Pow((smsKiekisUzsn-smsUzsienis),2)+Math.Pow((minKiekisUzsn-MinUzsienis),2)+Math.Pow((MBKiekisUzsn-mbUzsienis),2)+
                    Math.Pow((ApytiksleKaina-kaina),2)
                    );
                val.Properties[0].Atstumas = atstumas;
                //MessageBox.Show(zmz + l[0].ToString()+ min +" "+ nb );
                /*double atstumas = Math.Sqrt((sms - zmz) * (sms - zmz) + (min - mim) * (min - mim) +
                    (mb - nb) * (mb - nb) + (usms - zmzu) * (usms - zmzu) +
                    (umin - mimu) * (umin - mimu) + (umb - nbu) * (umb - nbu));*/
                //Atstumai.Add(atstumas); // sqrt((x-x)"2+(y-y)"2)
            }
            OLEGUI = OLEGUI.OrderBy(x => x.Properties[0].Atstumas).ToList();
            //OLEGUI = a;
            dataGridView1.Rows.Clear();
            int rowCountas = 0;
            foreach (var val in OLEGUI)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[rowCountas].Cells[0].Value = val.Properties[0].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[1].Value = val.Properties[2].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[2].Value = val.Properties[3].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[3].Value = val.Properties[4].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[4].Value = val.Properties[5].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[5].Value = val.Properties[6].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[6].Value = val.Properties[7].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[7].Value = val.Properties[8].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[8].Value = val.Properties[0].Atstumas;
                rowCountas++;
            }
            MessageBox.Show("DONE");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DuomenuParuosimas.Klases.Generate Generate = new DuomenuParuosimas.Klases.Generate();
            var Properciai = Generate.GetAllProperties(@"C:\Users\Rolandas\Desktop\Planai-su-diagrama.xlsx"); //Savo patha reiks nurodyti(galima bus padaryt kad pasirenki excelio faila) 
            OLEGUI = Generate.Uzpildymas(@"C:\Users\Rolandas\Desktop\Planai-su-diagrama.xlsx", Properciai);
            int rowCountas = 0;
            foreach (var val in OLEGUI)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[rowCountas].Cells[0].Value = val.Properties[0].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[1].Value = val.Properties[2].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[2].Value = val.Properties[3].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[3].Value = val.Properties[4].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[4].Value = val.Properties[5].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[5].Value = val.Properties[6].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[6].Value = val.Properties[7].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[7].Value = val.Properties[8].PropercioReiksme;
                dataGridView1.Rows[rowCountas].Cells[8].Value = val.Properties[0].Atstumas;
                rowCountas++;
            }
            //MessageBox.Show("WTF kas per gitas");
        }

        private void reiksmiuEventas(object sender, EventArgs e)
        {
            if (galimaKeistiReiksme)
            {
                ((TextBox)sender).Text = "bandymas";
                galimaKeistiReiksme = false;
            }
            else
            {
                galimaKeistiReiksme = true;
            }
        }


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
    }
}
