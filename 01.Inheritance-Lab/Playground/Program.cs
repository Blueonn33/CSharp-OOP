namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Martin");
            employee.Address = "Veliko Tarnovo";

            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Address);
        }
    }
}

public class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name
    {
        get; set;
    }
    public string Address
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
    public Employee(string name) : base(name)
    {
    }

    public string Company
    {
        get; set;
    }
}

public class Student : Person
{
    public Student(string name) : base(name)
    {
    }

    public string University
    {
        get; set;
    }
}

public class Manager : Employee
{
    public Manager(string name) : base(name)
    {
    }

    public string Department
    {
        get; set;
    }
    public List<Employee> Employees
    {
        get; set;
    }
}