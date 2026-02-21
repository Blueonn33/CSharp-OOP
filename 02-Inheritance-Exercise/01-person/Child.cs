using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {
            
        }

        public override string ToString()
        {
            return $"Child -> Name: {Name}, Age: {Age}";
        }
    }
}
