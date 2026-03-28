using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;
using System.Collections.ObjectModel;

namespace BlackFriday.Repositories
{
    public class ProductRepository : IRepository<IProduct>
    {
        private readonly List<IProduct> models;
        public IReadOnlyCollection<IProduct> Models
        {
            get;
        }

        public ProductRepository()
        {
            models = new List<IProduct>();
            Models = new ReadOnlyCollection<IProduct>(models);
        }

        public void AddNew(IProduct model)
        {
            models.Add(model);
        }

        public bool Exists(string name)
        {
            return models.Any(p => p.ProductName == name);
        }

        public IProduct GetByName(string name)
        {
            return models.FirstOrDefault(x => x.ProductName == name);
        }
    }
}
