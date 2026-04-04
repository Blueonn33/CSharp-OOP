using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private GuildRepository guilds;

        public Controller()
        {
            heroes = new HeroRepository();
            guilds = new GuildRepository();
        }
        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != nameof(Warrior) && heroTypeName != nameof(Sorcerer) && heroTypeName != nameof(Spellblade))
            {
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
            }

            var allHeroes = heroes.GetAll();

            if (allHeroes.Any(h => h.RuneMark == runeMark))
            {
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);
            }

            var hero = heroes.GetModel(runeMark);
            heroes.AddModel(hero);

            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            var allGuilds = guilds.GetAll();

            if (allGuilds.Any(h => h.Name == guildName))
            {
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);
            }

            return string.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            throw new NotImplementedException();
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            throw new NotImplementedException();
        }

        public string TrainingDay(string guildName)
        {
            throw new NotImplementedException();
        }

        public string ValorState()
        {
            throw new NotImplementedException();
        }
    }
}
