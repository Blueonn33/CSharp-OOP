using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System.Collections.ObjectModel;

namespace BlackFriday.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private readonly List<IUser> models;
        public IReadOnlyCollection<IUser> Models
        {
            get;
        }

        public UserRepository()
        {
            models = new List<IUser>();
            Models = new ReadOnlyCollection<IUser>(models);
        }

        public void AddNew(IUser model)
        {
            models.Add(model);
        }

        public bool Exists(string name)
        {
            return models.Any(p => p.UserName == name);
        }

        public IUser GetByName(string name)
        {
            return models.FirstOrDefault(x => x.UserName == name);
        }
    }
}
