using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> society = new();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IIdentifiable identifiable;

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    identifiable = new Citizen(name, age, id);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    identifiable = new Robot(model, id);
                }

                society.Add(identifiable);
            }

            string invalidSuffix = Console.ReadLine();

            foreach (IIdentifiable identifiable in society)
            {
                if (identifiable.Id.EndsWith(invalidSuffix))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }
        }
    }
}
