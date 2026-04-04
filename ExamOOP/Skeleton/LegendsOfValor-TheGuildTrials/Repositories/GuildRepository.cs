using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System.Collections.ObjectModel;
using LegendsOfValor_TheGuildTrials.Models;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private readonly List<IGuild> entities;
        public IReadOnlyCollection<IGuild> Entities
        {
            get;
        }

        public GuildRepository()
        {
            entities = new List<IGuild>();
            Entities = new ReadOnlyCollection<IGuild>(entities);
        }

        public void AddModel(IGuild entity)
        {
            entities.Add(entity);
        }

        public IReadOnlyCollection<IGuild> GetAll()
        {
            return Entities;
        }

        public IGuild GetModel(string guildName)
        {
            Guild guild = (Guild)entities.FirstOrDefault(g =>
                g.Name == guildName);

            return guild;
        }
    }
}
