using Playground;

public class Program
{
    public static void Main()
    {
        var catType = typeof(Cat);

        Console.WriteLine(catType.FullName);
        Console.WriteLine(catType.IsAbstract);

        var types = new List<Type>();
        types.Add(catType);
        types.Add(typeof(Animal));
    }
}