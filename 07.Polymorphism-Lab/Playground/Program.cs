namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat
            {
                Name = "First"
            };

            cat.SayHello();
            cat.Mew();

            Mammal secondCat = new Cat
            {
                Name = "Second"
            };
            secondCat.SayHello();

            IAnimal thirdCat = new Cat
            {
                Name = "Third"
            };

            Dog dog = new Dog
            {
                Name = "Dogy"
            };

            List<Mammal> mammals = new List<Mammal>();
            mammals.Add(secondCat);
            mammals.Add(dog);

            foreach (var mammal in mammals)
            {
                Print(mammal);
            }

            Mammal someMammal = new Cat();
            var mammalCat = (Cat)someMammal;
            mammalCat.Mew();

            if (someMammal is Cat catMammal)
            {
                catMammal.Mew();
            }
            else if (someMammal is Dog dogMammal)
            {
                dogMammal.Bark();
            }

            var someNumber = 10;
            const int min = 0;
            const int max = 10;

            Console.WriteLine(someNumber is min or max ? "OK" : "NOK");

            Enumerable.Range(0, 100)
                .Where(x => x % 10 is var res && res >= 1 && res <= 3);

            //var castedMammal = (Cat)someMammal;
            var castedMammal = someMammal as Cat;

            if (castedMammal is null)
            {
                Console.WriteLine("Cat is null");
            }
            else
            {
                Console.WriteLine("Cat is dog");
            }
        }

        public static void Print(Mammal mammal)
        {
            mammal.SayHello();
        }
    }
}
