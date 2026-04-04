using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System.Collections.ObjectModel;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Guild : IGuild
    {
        private string name;
        private int wealth;
        private List<string> legion;
        private bool isFallen;

        public Guild(string name, int wealth, bool isFallen)
        {
            Name = name;
            Wealth = wealth;
            IsFallen = isFallen;
            legion = new List<string>();
            Legion = new ReadOnlyCollection<string>(legion);
        }

        public string Name
        {
            get => name;
            set
            {
                if (value != "WarriorGuild" || value != "SorcererGuild" || value != "ShadowGuild")
                {
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);
                }

                name = value;
            }
        }

        public int Wealth
        {
            get => wealth;
            set
            {
                wealth = 5000;
            }
        }

        public IReadOnlyCollection<string> Legion
        {
            get; set;
        }

        public bool IsFallen
        {
            get; set;
        }

        public void LoseWar()
        {
        }

        public void RecruitHero(IHero hero)
        {
            if (Wealth >= 500)
            {
                legion.Add(hero.RuneMark);
                Wealth -= 500;
            }
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            throw new NotImplementedException();
        }

        public void WinWar(int goldAmount)
        {
            throw new NotImplementedException();
        }
    }
}
