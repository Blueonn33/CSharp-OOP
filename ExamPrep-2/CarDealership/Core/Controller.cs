using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;
using System.Text;

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
            var formattedPrice = $"{vehicle.Price:F2}";

            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, formattedPrice);
        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Customer Report:");

            foreach (var customer in dealership.Customers.Models.OrderBy(n => n.Name))
            {
                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");

                if (customer.Purchases.Count == 0)
                {
                    sb.AppendLine("--none");
                }
                else
                {
                    foreach (var model in customer.Purchases.OrderBy(p => p))
                    {
                        sb.AppendLine($"--{model}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
            if (!dealership.Customers.Exists(customerName))
            {
                return string.Format(OutputMessages.CustomerNotFound, customerName);
            }

            if (!dealership.Vehicles.Exists(vehicleTypeName))
            {
                return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);
            }

            ICustomer customer = dealership.Customers.Get(customerName);

            string customerType = customer.GetType().Name;

            if (customerType == nameof(IndividualClient) && vehicleTypeName == nameof(Truck) || customerType == nameof(LegalEntityCustomer) && vehicleTypeName == nameof(SaloonCar))
            {
                return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);
            }

            List<IVehicle> vehicles = dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName && v.Price <= budget)
                .ToList();

            if (vehicles.Count == 0)
            {
                return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);
            }

            IVehicle vehicle = vehicles.MaxBy(p => p.Price);

            customer.BuyVehicle(vehicle.Model);
            vehicle.SellVehicle(customerName);

            return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customerName, vehicle.Model);
        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{vehicleTypeName} Sales Report:");

            List<IVehicle> vehicles = dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName)
                .ToList();

            foreach (var vehicle in vehicles.OrderBy(m => m.Model))
            {
                sb.AppendLine($"--{vehicle.ToString()}");
            }

            sb.AppendLine($"Total Purchases: {vehicles.Sum(v => v.SalesCount)}");

            return sb.ToString().TrimEnd();
        }
    }
}
