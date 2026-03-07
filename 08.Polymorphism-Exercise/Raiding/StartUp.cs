namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IHero> heroes = new List<IHero>(capacity: n);

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                IHero? currentHero = null;

                if (type == "Druid")
                {
                    currentHero = new Druid { Name = name };
                }
                else if (type == "Paladin")
                {
                    currentHero = new Paladin { Name = name };
                }
                else if (type == "Rogue")
                {
                    currentHero = new Rogue { Name = name };
                }
                else if (type == "Warrior")
                {
                    currentHero = new Warrior { Name = name };
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }

                if (currentHero is not null)
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
