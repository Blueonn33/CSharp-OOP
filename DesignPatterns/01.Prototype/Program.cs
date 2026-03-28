namespace _01.Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(21, "Martin", new Laptop("Acer", 3200));

            Student student2 = student1.Clone();

            student2.Name = "Raya";
            student2.Age = 18;
            student2.Laptop.Price = 1800;

            Console.WriteLine(student1.Name);
            Console.WriteLine(student1.Age);
            Console.WriteLine(student1.Laptop.Brand);
            Console.WriteLine(student1.Laptop.Price);

            Console.WriteLine("=====================");
            Console.WriteLine(student2.Name);
            Console.WriteLine(student2.Age);
            Console.WriteLine(student2.Laptop.Brand);
            Console.WriteLine(student2.Laptop.Price);
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
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public Laptop Laptop
        {
            get; set;
        }

        public Student Clone()
        {
            return new Student(Age, Name, new Laptop(Laptop.Brand, Laptop.Price));
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
