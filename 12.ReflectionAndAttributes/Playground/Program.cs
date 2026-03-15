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

        var animalType = Type.GetType("Playground.Animal");
        var animal = new Cat("Sharo", "Purple");

        var sharoType = animalType.GetType();

        Console.WriteLine(sharoType.FullName);
        Console.WriteLine(sharoType.IsAbstract);

        var baseType = sharoType.BaseType;
        Console.WriteLine(baseType.FullName);

        var interfaces = sharoType.GetInterfaces();

        foreach (var interfaceType in interfaces)
        {
            Console.WriteLine(interfaceType.FullName);
        }
    }
}