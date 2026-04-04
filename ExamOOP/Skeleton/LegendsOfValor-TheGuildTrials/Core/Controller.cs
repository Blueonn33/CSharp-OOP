using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System.Text;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly GuildRepository guilds;

        public Controller()
        {
            heroes = new HeroRepository();
            guilds = new GuildRepository();
        }

        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroTypeName != nameof(Warrior) && heroTypeName != nameof(Sorcerer) && heroTypeName != nameof(Spellblade))
                return string.Format(OutputMessages.InvalidHeroType, heroTypeName);

            if (heroes.GetAll().Any(h => h.RuneMark == runeMark))
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);

            IHero hero = heroTypeName switch
            {
                nameof(Warrior) => new Warrior(heroName, runeMark),
                nameof(Sorcerer) => new Sorcerer(heroName, runeMark),
                nameof(Spellblade) => new Spellblade(heroName, runeMark),
                _ => null
            };

            heroes.AddModel(hero);
            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetAll().Any(g => g.Name == guildName))
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);

            IGuild guild = new Guild(guildName);
            guilds.AddModel(guild);

            return string.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            IHero hero = heroes.GetModel(runeMark);
            if (hero == null)
                return string.Format(OutputMessages.HeroNotFound, runeMark);

            IGuild guild = guilds.GetModel(guildName);
            if (guild == null)
                return string.Format(OutputMessages.GuildNotFound, guildName);

            if (hero.GuildName != null)
                return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);

            if (guild.IsFallen)
                return string.Format(OutputMessages.GuildIsFallen, guildName);

            if (guild.Wealth < 500)
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guildName);

            bool isAllowed = hero switch
            {
                Warrior => guildName == "WarriorGuild" || guildName == "ShadowGuild",
                Sorcerer => guildName == "SorcererGuild" || guildName == "ShadowGuild",
                Spellblade => guildName == "WarriorGuild" || guildName == "SorcererGuild",
                _ => false
            };

            if (!isAllowed)
                return string.Format(OutputMessages.HeroTypeNotCompatible, hero.GetType().Name, guildName);

            hero.JoinGuild(guild);
            guild.RecruitHero(hero);

            return string.Format(OutputMessages.HeroRecruited, hero.Name, guildName);
        }

        public string TrainingDay(string guildName)
        {
            IGuild guild = guilds.GetModel(guildName);
            if (guild == null)
                return string.Format(OutputMessages.GuildNotFound, guildName);

            if (guild.IsFallen)
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);

            List<IHero> heroesToTrain = guild.Legion
                .Select(rm => heroes.GetModel(rm))
                .Where(h => h != null)
                .ToList();

            int totalTrainingCost = heroesToTrain.Count * 200;
            if (guild.Wealth < totalTrainingCost)
                return string.Format(OutputMessages.TrainingDayFailed, guildName);

            guild.TrainLegion(heroesToTrain);
            return string.Format(OutputMessages.TrainingDayStarted, guildName, heroesToTrain.Count, totalTrainingCost);
        }

        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            IGuild attackerGuild = guilds.GetModel(attackerGuildName);
            IGuild defenderGuild = guilds.GetModel(defenderGuildName);

            if (attackerGuild == null || defenderGuild == null)
                return string.Format(OutputMessages.OneOfTheGuildsDoesNotExist);

            if (attackerGuild.IsFallen || defenderGuild.IsFallen)
                return string.Format(OutputMessages.OneOfTheGuildsIsFallen);

            int attackerPower = attackerGuild.Legion.Sum(rm =>
            {
                IHero hero = heroes.GetModel(rm);
                return hero.Power + hero.Mana + hero.Stamina;
            });

            int defenderPower = defenderGuild.Legion.Sum(rm =>
            {
                IHero hero = heroes.GetModel(rm);
                return hero.Power + hero.Mana + hero.Stamina;
            });

            if (attackerPower > defenderPower)
            {
                int goldWon = defenderGuild.Wealth;
                attackerGuild.WinWar(goldWon);
                defenderGuild.LoseWar();
                return string.Format(OutputMessages.WarWon, attackerGuildName, defenderGuildName, goldWon);
            }
            else
            {
                int goldWon = attackerGuild.Wealth;
                defenderGuild.WinWar(goldWon);
                attackerGuild.LoseWar();
                return string.Format(OutputMessages.WarLost, defenderGuildName, goldWon, attackerGuildName);
            }
        }

        public string ValorState()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Valor State:");

            foreach (IGuild guild in guilds.GetAll().OrderByDescending(g => g.Wealth))
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");

                var guildHeroes = guild.Legion
                    .Select(rm => heroes.GetModel(rm))
                    .Where(h => h != null)
                    .OrderBy(h => h.Name);

                foreach (IHero hero in guildHeroes)
                {
                    sb.AppendLine($"-Hero: [{hero.Name}] of the Guild '{hero.GuildName}' - RuneMark: {hero.RuneMark}");
                    sb.AppendLine($"--Essence Revealed - Power [{hero.Power}] Mana [{hero.Mana}] Stamina [{hero.Stamina}]");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}