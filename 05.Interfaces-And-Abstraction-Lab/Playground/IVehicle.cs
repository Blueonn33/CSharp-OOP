using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public interface IVehicle
    {
        public string Model
        {
            get; set;
        }
        public string Manufacturer
        {
            get; set;
        }
        public int Year
        {
            get; set;
        }

        public void Start();
        public void Stop();
        public void Move();
    }
}
