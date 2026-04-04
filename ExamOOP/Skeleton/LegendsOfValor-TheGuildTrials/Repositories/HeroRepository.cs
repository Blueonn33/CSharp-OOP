using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System.Collections.ObjectModel;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> entities;

        public HeroRepository()
        {
            this.entities = new List<IHero>();
        }

        public void AddModel(IHero entity)
        {
            this.entities.AddHero(entity);
        }

        public IReadOnlyCollection<IHero> GetAll()
        {
            return new ReadOnlyCollection<IHero>(this.entities);
        }

        public IHero GetModel(string runeMark)
        {
            return this.entities.FirstOrDefault(h => h.RuneMark == runeMark);
        }
    }
}