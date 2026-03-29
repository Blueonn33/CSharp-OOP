using CarDealership.Core.Contracts;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        public string AddCustomer(string customerTypeName, string customerName)
        {
            throw new NotImplementedException();
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            throw new NotImplementedException();
        }

        public string CustomerReport()
        {
            throw new NotImplementedException();
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            throw new NotImplementedException();
        }

        public string SalesReport(string vehicleTypeName)
        {
            throw new NotImplementedException();
        }
    }
}
