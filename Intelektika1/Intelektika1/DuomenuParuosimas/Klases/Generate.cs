using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Intelektika1.DuomenuParuosimas.Klases
{
    class Generate : Interface.IPrepare
    {
        /// <summary>
        /// Uzpildau viska duomenemys.
        /// </summary>
        /// <param name="keliasIkiExcelio"></param>
        /// <param name="Properties"></param>
        /// <returns></returns>
        public List<Reiksmes>Uzpildymas(string keliasIkiExcelio,List<PlanuProperty>Properties)
        {
            List<Reiksmes> test = new List<Reiksmes>();
            if (File.Exists(keliasIkiExcelio))
            {

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(keliasIkiExcelio);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[2];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                try
                {
                    for(int row=1; row<100;row++) //double foras nes reikia kiekviena fillinti ir as nezinau kiek ju gali buti. Yra ir efektyvesnis sprendimas bet tingiu galvot (nes uzimtu laiko)
                    {
                        List<PlanuProperty> Naujas = new List<PlanuProperty>(Properties.Count);//
                        Properties.ForEach((item) =>
                        {
                            Naujas.Add(new PlanuProperty(item.PropercioPavadinimas, item.PropercioReiksme));
                        });// Deep copy ilgai aiskinti kas tai yra. Bet taip reik daryt nes listas yra REFERANCE TYPO
                        for (int col=1;col<=Properties.Count;col++)//Columus jau zinom
                        {
                             Naujas[col-1].PropercioReiksme = xlRange.Cells[row, col].Value.ToString();
                        }
                         test.Add(new Reiksmes(Naujas));
                    }
                }
                catch (Exception ex)//jeigu value bus tuscias reiskias jau perejo visus ir rado pabaiga.
                {
                    xlWorkbook.Close(false, keliasIkiExcelio);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    KillExcel();
                }
            }
            return test;
        }
        /// <summary>
        /// Dinamiskai pasiemu visus propercius kurie yra
        /// </summary>
        /// <param name="keliasIkiExcelio"></param>
        /// <returns></returns>
        public List<PlanuProperty> GetAllProperties(string keliasIkiExcelio)
        {
            List<PlanuProperty> PlanuProperciai = new List<PlanuProperty>();//Isskyriu vieta naujam listui
            if (File.Exists(keliasIkiExcelio))
            {
                
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(keliasIkiExcelio);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;
                try
                {
                    for (int col = 2; col < 100; col++)
                    {
                        if (xlRange.Cells[1, col].Value.ToString() == null || xlRange.Cells[1, col].Value.ToString() == "")//jeigu tuscias cellas reiskias viskas praejo. daugiau nebus
                        {
                            break;
                        }
                        else
                        {
                            PlanuProperciai.Add(new PlanuProperty(xlRange.Cells[1, col].Value.ToString(),null));//null nes bus n tokiu tai tik rezervuoju vieta(bet neisskiriu vieta del to null)
                        }

                    }
                }
                catch (Exception ex)//jeigu value bus tuscias reiskias jau perejo visus ir rado pabaiga.
                {
                    xlWorkbook.Close(false,keliasIkiExcelio);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                }
            }
            return PlanuProperciai;
        }
        /// <summary>
        /// Killina Visus excelio procesus nes catchas tik atminti isvalo, bet nekilina procu bbz kodel
        /// </summary>
        protected void KillExcel()
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Equals("EXCEL"))
                {
                    clsProcess.Kill();
                    break;
                }
            }
        }
    }
}
