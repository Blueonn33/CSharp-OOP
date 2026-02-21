using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public string Gender
        {
            get => gender;
            set { gender = value; }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name}\n{Name} {Age} {Gender}";
        }
    }
}