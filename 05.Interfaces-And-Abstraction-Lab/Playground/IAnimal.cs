using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string SayHello();
    }
}
