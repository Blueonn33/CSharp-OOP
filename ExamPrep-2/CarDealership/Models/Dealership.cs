using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Models
{
    public class Dealership : IDealership
    {
        public IRepository<IVehicle> Vehicles
        {
            get;
        }
        public IRepository<ICustomer> Customers
        {
            get;
        }
    }
}
