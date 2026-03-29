using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        public IReadOnlyCollection<ICustomer> Models
        {
            get;
        }
        public void Add(ICustomer model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string text)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string text)
        {
            throw new NotImplementedException();
        }

        public ICustomer Get(string text)
        {
            throw new NotImplementedException();
        }
    }
}
