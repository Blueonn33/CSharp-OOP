using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : Car, ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery) : base(model, color)
        {
            Battery = battery;
        }
        public int Battery
        {
            get; private set;
        }

        public override string ToString()
        {
            return base.ToString() + $"with {Battery} Batteries";
        }
    }
}
