using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Models
{
    public class Dealership : IDealership
    {
        private readonly IRepository<IVehicle> vehicleRepository;
        private readonly IRepository<ICustomer> customerRepository;

        public Dealership()
        {
            vehicleRepository = new VehicleRepository();
            customerRepository = new CustomerRepository();
        }

        public IRepository<IVehicle> Vehicles => vehicleRepository;
        public IRepository<ICustomer> Customers => customerRepository;
    }
}
