public interface IPerson
{
    string Job
    {
        get;
    }
}

public interface ILivingCreature
{
    string Name
    {
        get;
    }
    int Age
    {
        get;
    }
}

public class Person : ILivingCreature, IPerson
{
    public string Name
    {
        get;
    }
    public int Age
    {
        get; set;
    }
    public string Job
    {
        get; set;
    }

    public Person(string name, int age, string job)
    {
        Name = name;
        Age = age;
        Job = job;
    }
}

public class Pet : ILivingCreature
{
    public string Name
    {
        get;
    }
    public int Age
    {
        get;
    }
}
