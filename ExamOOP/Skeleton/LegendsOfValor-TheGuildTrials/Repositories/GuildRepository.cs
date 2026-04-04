using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System.Collections.ObjectModel;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private readonly List<IGuild> entities;

        public GuildRepository()
        {
            this.entities = new List<IGuild>();
        }

        public void AddModel(IGuild entity)
        {
            this.entities.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return new ReadOnlyCollection<IGuild>(this.entities);
        }

        public IGuild GetModel(string guildName)
        {
            return this.entities.FirstOrDefault(h => h.Name == guildName);
        }
    }
}