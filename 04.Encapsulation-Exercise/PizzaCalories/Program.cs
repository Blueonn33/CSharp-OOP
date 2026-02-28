using PizzaCalories.Models;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split();
                string[] doughTokens = Console.ReadLine().Split();

                Pizza pizza = new Pizza(pizzaTokens[1]);
                Dough dough = new Dough(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));

                pizza.Dough = dough;

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] toppingTokens = command.Split();
                    Topping topping = new Topping(toppingTokens[1], double.Parse(toppingTokens[2]));

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
