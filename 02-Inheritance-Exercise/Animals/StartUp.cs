namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animalType = Console.ReadLine();
            string[] animalInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (animalType != "Beast!")
            {
                string name = animalInput[0];
                int age = int.Parse(animalInput[1]);
                string gender = animalInput[2];

                try
                {
                    Animal animal = null;

                    switch (animalType)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;
                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;
                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }

                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animalType = Console.ReadLine();
                animalInput = Console.ReadLine().Split();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
