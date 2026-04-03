using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (personData.Length == 4)
                {
                    buyers.Add(new Citizen(
                        personData[0],
                        int.Parse(personData[1]),
                        personData[2],
                        personData[3]));
                }
                else
                {
                    buyers.Add(new Rebel(
                        personData[0],
                        int.Parse(personData[1]),
                        personData[2]));
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers
                    .FirstOrDefault(b => (b as INameable).Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}