using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public abstract class Animal : IAnimal
    {
        public string Name
        {
            get; set;
        }

        public int Age { get; set; }

        public string SayName()
        {
            return this.Name;
        }

        public abstract string SayHello();
        public abstract void Move();
    }
}
