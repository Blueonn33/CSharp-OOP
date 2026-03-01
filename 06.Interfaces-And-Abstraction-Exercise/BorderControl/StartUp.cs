using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> society = new();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IBirthable birthable;

                string type = tokens[0];

                switch (type)
                {
                    case "Citizen":
                        birthable = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                        break;
                    case "Pet":
                        birthable = new Pet(tokens[1], tokens[2]);
                        break;
                    default:
                        continue;
                }

                society.Add(birthable);
            }

            string year = Console.ReadLine();

            foreach (IBirthable entity in society)
            {
                if (entity.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(entity.Birthdate);
                }
            }
        }
    }
}
