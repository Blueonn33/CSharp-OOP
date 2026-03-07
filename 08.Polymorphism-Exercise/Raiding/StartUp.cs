namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<string, IHero>> factory = new Dictionary<string, Func<string, IHero>>
            {
                ["Druid"] = (name) => new Druid { Name = name },
                ["Paladin"] = (name) => new Paladin { Name = name },
                ["Rogue"] = (name) => new Rogue { Name = name },
                ["Warrior"] = (name) => new Warrior { Name = name },
            };

            int n = int.Parse(Console.ReadLine());
            List<IHero> heroes = new List<IHero>(capacity: n);

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                IHero? currentHero = null;

                if (!factory.ContainsKey(type))
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    heroes.Add(currentHero);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int sum = 0;

            foreach (IHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                sum += hero.Power;
            }

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
