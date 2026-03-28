using _01.Prototype.Models;

namespace _01.Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new();

            menu["BLT"] = new Sandwich("White", "Bacon", "Cheese", "Tomato, Cucumber");

            SandwichPrototype sandwich = menu["BLT"].Clone();
        }
    }

}
