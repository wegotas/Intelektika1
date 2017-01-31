﻿using System;
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
        bool keistiReiksme = true;

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
    }
}
