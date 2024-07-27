using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steinhart_Hart
{
    public partial class AddDialog : Form
    {
        public AddDialog()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //TODO add more validation
            if (txtTemp.Text.Length > 0 && txtRes.Text.Length > 0)  //Just basic validation 
            {
                try
                {
                    double temp = double.Parse(txtTemp.Text);
                    double res = double.Parse(txtRes.Text);
                    observer.AddTempReading(temp, res);
                }
                catch { }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}
