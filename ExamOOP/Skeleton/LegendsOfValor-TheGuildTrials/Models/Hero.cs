using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public abstract class Hero
    {
        private string name;
        private string runeMark;
        private string guildName;

        public Hero(string name, string runeMark, int power, int mana, int stamina)
        {
            Name = name;
            RuneMark = runeMark;
            Power = power;
            Mana = mana;
            Stamina = stamina;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroName);
                }

                name = value;
            }
        }

        public string RuneMark
        {
            get => runeMark;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroRuneMark);
                }

                runeMark = value;
            }
        }

        public string GuildName
        {
            get; private set;
        }

        public int Power
        {
            get; private set;
        }

        public int Mana
        {
            get; private set;
        }
        public int Stamina
        {
            get; private set;
        }
    }
}
