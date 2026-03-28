namespace _01.Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Student
    {
        public Student(int age, string name, Laptop laptop)
        {
            Age = age;
            Name = name;
            Laptop = laptop;
        }

        public int Age
        {
            get; private set;
        }
        public string Name
        {
            get; private set;
        }
        public Laptop Laptop
        {
            get; set;
        }

        public Student Clone()
        {
            return MemberwiseClone() as Student;
        }
    }

    public class Laptop
    {
        public Laptop(string brand, decimal price)
        {
            Brand = brand;
            Price = price;
        }

        public string Brand
        {
            get; private set;
        }
        public decimal Price
        {
            get; set;
        }
    }
}
