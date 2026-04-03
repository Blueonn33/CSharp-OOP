using WildFarm.Abstract;
using WildFarm.BirdModels;
using WildFarm.FelineModels;
using WildFarm.FoodModels;
using WildFarm.MammalModels;

namespace WildFarm
{
    public class Program
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                Animal animal = CreateAnimal(input);

                string[] foodInfo = Console.ReadLine().Split();
                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                Food food = CreateFood(foodType, quantity);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal CreateAnimal(string input)
        {
            string[] parts = input.Split();
            string type = parts[0];
            string name = parts[1];
            double weight = double.Parse(parts[2]);

            switch (type)
            {
                case "Owl":
                    double wingSizeOwl = double.Parse(parts[3]);
                    return new Owl(name, weight, wingSizeOwl);

                case "Hen":
                    double wingSizeHen = double.Parse(parts[3]);
                    return new Hen(name, weight, wingSizeHen);

                case "Mouse":
                    string regionMouse = parts[3];
                    return new Mouse(name, weight, regionMouse);

                case "Dog":
                    string regionDog = parts[3];
                    return new Dog(name, weight, regionDog);

                case "Cat":
                    string regionCat = parts[3];
                    string breedCat = parts[4];
                    return new Cat(name, weight, regionCat, breedCat);

                case "Tiger":
                    string regionTiger = parts[3];
                    string breedTiger = parts[4];
                    return new Tiger(name, weight, regionTiger, breedTiger);

                default:
                    throw new InvalidOperationException("Unknown animal type");
            }
        }

        private static Food CreateFood(string type, int quantity)
        {
            return type switch
            {
                "Vegetable" => new Vegetable(quantity),
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                _ => throw new InvalidOperationException("Unknown food type")
            };
        }
    }
}
