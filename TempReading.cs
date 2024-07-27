using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steinhart_Hart
{
    
    internal class TempReading
    {
       
         private readonly double Temp;
        
         private readonly double Resistance;
        private double Accuracy = 0;

        public TempReading(double temp, double resistance  )
        {
            this.Temp = temp;
            this.Resistance = resistance;
        }
        public TempReading(double temp, double resistance, double accuracy)
        {
            this.Temp = temp;
            this.Resistance = resistance;
            this.Accuracy = accuracy;
        }
        public double GetTemp()
        {
            return Temp;
        }

        public double GetAccuracy()
        {
            return Accuracy;
        }

        public void setAccuracy(double accuracy)
        {
            Accuracy = accuracy;
        }
        public double GetResistance()
        {
            return Resistance;
        }

        public override String  ToString()
            { return String.Format("{0:N2}C     {1:N2} Ohms    {2:N2} Accuracy     ", Temp, Resistance,Accuracy); }
    }
}
