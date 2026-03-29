using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private readonly IDealership dealership;

        public Controller()
        {
            dealership = new Dealership();
        }

        public string AddCustomer(string customerTypeName, string customerName)
        {
            if (customerTypeName != nameof(IndividualClient) && customerTypeName != nameof(LegalEntityCustomer))
            {
                return string.Format(OutputMessages.InvalidType, customerTypeName);
            }

            if (dealership.Customers.Exists(customerName))
            {
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);
            }

            ICustomer customer = customerName == nameof(IndividualClient)
                ? new IndividualClient(customerName)
                : new LegalEntityCustomer(customerName);

            dealership.Customers.Add(customer);

            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            if (vehicleTypeName != nameof(Truck) && vehicleTypeName != nameof(SaloonCar) && vehicleTypeName != nameof(SUV))
            {
                return string.Format(OutputMessages.InvalidType, vehicleTypeName);
            }

            if (dealership.Vehicles.Exists(model))
            {
                return string.Format(OutputMessages.VehicleAlreadyAdded, model);
            }

            IVehicle vehicle;

            if (vehicleTypeName == nameof(SaloonCar))
            {
                vehicle = new SaloonCar(model, price);
            }
            else if (vehicleTypeName == nameof(SUV))
            {
                vehicle = new SUV(model, price);
            }
            else
            {
                vehicle = new Truck(model, price);
            }

            dealership.Vehicles.Add(vehicle);
            var formattedPrice = $"{price:F2}";

            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, formattedPrice);
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
