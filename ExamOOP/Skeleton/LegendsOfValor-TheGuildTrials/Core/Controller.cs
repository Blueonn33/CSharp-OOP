using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
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
            var allHeroes = heroes.GetAll();

            if (!allHeroes.Any(h => h.RuneMark == runeMark))
            {
                return string.Format(OutputMessages.HeroNotFound, runeMark);
            }

            var allGuilds = guilds.GetAll();

            if (!allGuilds.Any(h => h.Name == guildName))
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            var hero = heroes.GetModel(runeMark);

            if (hero.GuildName != null)
            {
                return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);
            }

            var guild = guilds.GetModel(guildName);

            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildIsFallen, guildName);
            }

            if (guild.Wealth < 500)
            {
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guildName);
            }

            bool isAllowed = false;

            if (hero is Warrior)
            {
                isAllowed = guildName == "WarriorGuild" || guildName == "ShadowGuild";
            }
            else if (hero is Sorcerer)
            {
                isAllowed = guildName == "SorcererGuild" || guildName == "ShadowGuild";
            }
            else if (hero is Spellblade)
            {
                isAllowed = guildName == "WarriorGuild" || guildName == "SorcererGuild";
            }

            if (!isAllowed)
            {
                return string.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guildName);
            }

            hero.JoinGuild(guild);
            guild.RecruitHero(hero);

            return string.Format(OutputMessages.HeroRecruited, hero.Name, guildName);
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            throw new NotImplementedException();
        }

        public string TrainingDay(string guildName)
        {
            var allGuilds = guilds.GetAll();

            if (!allGuilds.Any(h => h.Name == guildName))
            {
                return string.Format(OutputMessages.GuildNotFound, guildName);
            }

            var guild = guilds.GetModel(guildName);

            if (guild.IsFallen)
            {
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);
            }

            var totalTrainingCost = guild.Legion.Count * 200;

            if (guild.Wealth < totalTrainingCost)
            {
                return string.Format(OutputMessages.TrainingDayFailed, guildName);
            }

            ICollection<IHero> heroesToTrain = new List<IHero>();

            foreach (string runeMark in guild.Legion)
            {
                IHero hero = heroes.GetModel(runeMark);

                if (hero != null)
                {
                    heroesToTrain.Add(hero);
                }
            }

            guild.TrainLegion(heroesToTrain);
            return string.Format(OutputMessages.TrainingDayStarted, guildName, guild.Legion.Count, totalTrainingCost);
        }

        public string ValorState()
        {
            throw new NotImplementedException();
        }
    }
}
