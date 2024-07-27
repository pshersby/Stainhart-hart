using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Data.Common;
using Microsoft.VisualBasic;
using System.Collections;

namespace Steinhart_Hart
{
    public partial class TempView : Form
    {

        Steinhart3 calculator = new Steinhart3();


        public TempView()
        {
            InitializeComponent();


            //Debug Dale 1T1002-5 Thermistor should give approximately C1 = 1.104, C2 = 2.389, C3 = 0.694

            lstTempReadings.Items.Add(new TempReading(0, 32128));
            lstTempReadings.Items.Add(new TempReading(10, 19549));
            lstTempReadings.Items.Add(new TempReading(20, 12262));
            lstTempReadings.Items.Add(new TempReading(25, 9814));
            lstTempReadings.Items.Add(new TempReading(30, 7908));
            lstTempReadings.Items.Add(new TempReading(40, 5331));
            lstTempReadings.Items.Add(new TempReading(50, 3542));
            this.txtThermistor.Text = "Dale 1T1002-5 Thermistor";
            this.RefreshCalc();
        }


        public void AddTempReading(double temp, double res)
        {
            TempReading tr = new TempReading(temp, res);
            this.lstTempReadings.Items.Add(tr); 
        }



        private void ClearTempReading()
        {
            this.lstTempReadings.Items.Clear();
            this.txtThermistor.Clear();


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            if (fileDlg.ShowDialog() != DialogResult.OK)
                return;

            string filename = fileDlg.FileName;
            if (filename == null) return;
            parseFile(filename);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            lstTempReadings.Items.RemoveAt(lstTempReadings.SelectedIndex);
            RefreshCalc();
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            RefreshCalc();
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            this.ClearTempReading();    

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDialog dlg = new AddDialog();
            dlg.Subscribe(this);
            dlg.ShowDialog();
            RefreshCalc();

        }

        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            

            if (e.Data !=null && e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            
            if (e.Data == null  || !e.Data.GetDataPresent(DataFormats.FileDrop,false) ) return;
            {
                
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files == null) return;

                string file = files.First();
                MessageBox.Show(file);
                parseFile(file);
                    
            }
                
        }
        // Parses a temperature data file and populates listbox, then runs calculation
        // Every line is required to have 2 fields, in the format temp,resistance, 
        // every reading on a seprate line
        // no limit to readings but each unique
        // lines starting with # or ! are ignored and may be used for comments and titles
        private void parseFile(String pathname)
        {
            this.ClearTempReading();
            string title = "";
            double temp = 0 ;
            double res= 0;
            string[] splitline;
            List<TempReading> tr = new List<TempReading>();



            var lines = File.ReadLines(pathname);
            if (lines.Count() < 1) return;
            
            //We have some data to read so clear the box and get ready
            this.ClearTempReading();
            bool hasTitle = false;
            foreach (string line in lines){
                line.Trim();
                if (line.Length<1 || line.StartsWith("#")|| line.StartsWith("!")) continue; 
                splitline = line.Split(',');
                if (splitline[0].ToUpper().StartsWith("TITLE") && !hasTitle)
                {
                    hasTitle = true;
                    title = splitline[1];

                }
                else
                {
                    try
                    {
                        TempReading t = new TempReading(double.Parse(splitline[0]), double.Parse(splitline[1]), 0);
                        tr.Add(t);

                    }
                    catch {  }  // If we error we must abandon
                    
                }
                
              

            }// end of foreach
            foreach (TempReading t in tr)
            {
                AddTempReading(t.GetTemp(), t.GetResistance());
            }
            txtThermistor.Text = title;
            this.RefreshCalc();


        }

        private void RefreshCalc()
        {
            TempReading[] tr = new TempReading[lstTempReadings.Items.Count];
            lstTempReadings.Items.CopyTo(tr, 0);
            calculator.CalcCoefficients(tr);
            lstTempReadings.Items.Clear();
            lstTempReadings.Items.AddRange(tr); 
            txtC1.Text = String.Format("{0:N3}", calculator.getC1());
            txtC2.Text = String.Format("{0:N3}", calculator.getC2());
            txtC3.Text = String.Format("{0:N3}", calculator.getC3());
            //lstTempReadings.Refresh();  

        }
    }
}
