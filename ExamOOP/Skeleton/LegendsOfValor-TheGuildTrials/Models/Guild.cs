using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Guild : IGuild
    {
        private string name;
        private int wealth;
        private List<string> legion;

        public Guild(string name)
        {
            Name = name;
            Wealth = 5000;
            legion = new List<string>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (value != "WarriorGuild" && value != "SorcererGuild" && value != "ShadowGuild")
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);
                name = value;
            }
        }

        public int Wealth
        {
            get => wealth;
            set
            {
                if (value >= 0)
                    wealth = value;
            }
        }

        public IReadOnlyCollection<string> Legion => legion;

        public bool IsFallen
        {
            get; set;
        }

        public void LoseWar()
        {
            IsFallen = true;
            Wealth = 0;
        }

        public void RecruitHero(IHero hero)
        {
            if (Wealth >= 500)
            {
                legion.AddHero(hero.RuneMark);
                Wealth -= 500;
            }
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            foreach (var hero in heroesToTrain)
            {
                if (Wealth >= 200)
                {
                    hero.Train();
                    Wealth -= 200;
                }
                else
                    break;
            }
        }

        public void WinWar(int goldAmount)
        {
            Wealth += goldAmount;
        }
    }
}