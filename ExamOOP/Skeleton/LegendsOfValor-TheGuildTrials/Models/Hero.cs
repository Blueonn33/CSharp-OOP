using LegendsOfValor_TheGuildTrials.Models.Contracts;
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

        public void JoinGuild(IGuild guild)
        {
            GuildName = guild.Name;
        }

        public abstract void Train();

        public string Essence()
        {
            return $"Essence Revealed - Power [{Power}] Mana [{Mana}] Stamina [{Stamina}]";
        }

        public override string ToString()
        {
            return $"Hero: [{Name}] of the Guild '{GuildName}' - RuneMark: {RuneMark}";
        }
    }
}
