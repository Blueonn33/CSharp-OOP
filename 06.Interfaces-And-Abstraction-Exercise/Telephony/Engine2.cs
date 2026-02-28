using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;

namespace Telephony
{
    public class Engine2 : IEngine
    {
        public void Run()
        {
            Console.WriteLine("Fake engine");
        }
    }
}
