namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
          Employee employee = new Employee("John Doe", "Acme Inc.");

          employee.PrintAge();
        }
    }
}

public class Person
{
    public int age = 15;
    public Person(string name)
    {
        Name = name;
    }

    public string Name
    {
        get; set;
    }
    protected string Address
    {
        get; set;
    }
    public void PrintName(string name)
    {

        if (name.Length < 3)
        {
            throw new ArgumentException("Name is too short");
        }

        Console.WriteLine("Employee name: " + name);
    }
}

public class Employee : Person
{
    public bool age = true;

    public void PrintAge()
    {
        string age = "Age is not available";

        Console.WriteLine(age);
        Console.WriteLine(this.age);
        Console.WriteLine(base.age);
    }

    public Employee(string name, string company) : base(name)
    {
        Company = company;
        Address = "123 Main St";
    }

    public string Company { get; set; }
}