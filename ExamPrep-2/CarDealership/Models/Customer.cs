using CarDealership.Models.Contracts;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        public string Name => throw new NotImplementedException();

        public IReadOnlyCollection<string> Purchases => throw new NotImplementedException();

        public void BuyVehicle(string vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
