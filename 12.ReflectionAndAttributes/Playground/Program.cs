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
            Console.WriteLine(interfaceType.IsPublic);
        }

        var constructors = catType.GetConstructors();

        foreach (var constructor in constructors)
        {
            var parameters = constructor.GetParameters();

            foreach (var parameter in parameters)
            {
                Console.WriteLine($"{parameter.Name} - {parameter.ParameterType}");
            }

            //Console.WriteLine(string.Join(", ", constructor.GetParameters().Select(p => p.Name)));
        }

        var emptyCtor = catType.GetConstructor(new Type[0]);

        var catFromConstructor = (Cat)emptyCtor.Invoke(new object[0]);

        Console.WriteLine(catFromConstructor.Name);
    }
}