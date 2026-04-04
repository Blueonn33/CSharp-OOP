using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System.Collections.ObjectModel;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> entities;
        public IReadOnlyCollection<IHero> Entities
        {
            get;
        }

        public HeroRepository()
        {
            entities = new List<IHero>();
            Entities = new ReadOnlyCollection<IHero>(entities);
        }

        public void AddModel(IHero entity)
        {
            entities.Add(entity);
        }

        public IReadOnlyCollection<IHero> GetAll()
        {
            return Entities;
        }

        public IHero GetModel(string runeMarkOrGuildName)
        {
            Hero hero = (Hero)entities.FirstOrDefault(h =>
                h.RuneMark == runeMarkOrGuildName || h.GuildName == runeMarkOrGuildName);

            return hero;
        }
    }
}
