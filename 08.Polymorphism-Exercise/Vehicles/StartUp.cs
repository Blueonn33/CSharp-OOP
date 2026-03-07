namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IVehicle> vehicles = new Dictionary<string, IVehicle>();

            string[] carData = Console.ReadLine().Split();
            vehicles["Car"] = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));

            string[] truckData = Console.ReadLine().Split();
            vehicles["Truck"] = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));

            string[] busData = Console.ReadLine().Split();
            vehicles["Bus"] = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandsData = Console.ReadLine().Split();
                string command = commandsData[0];

                if (command == "Drive")
                {
                    Drive(commandsData[1], vehicles, double.Parse(commandsData[2]));
                }
                if (command == "DriveEmpty")
                {

                }
                else if (command == "Refuel")
                {
                    Refuel(commandsData[1], vehicles, double.Parse(commandsData[2]));
                }
            }

            PrintInfo("Car", vehicles);
            PrintInfo("Truck", vehicles);
            PrintInfo("Bus", vehicles);
        }

        private static void Drive(string id, Dictionary<string, IVehicle> vehicles, double distance)
        {
            if (!vehicles.ContainsKey(id))
            {
                return;
            }

            IVehicle vehicle = vehicles[id];

            if (vehicle.Drive(distance))
            {
                Console.WriteLine($"{id} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{id} needs refueling");
            }
        }

        private static void Refuel(string id, Dictionary<string, IVehicle> vehicles, double fuelQuantity)
        {
            try
            {
                if (!vehicles.ContainsKey(id))
                {
                    return;
                }

                IVehicle vehicle = vehicles[id];

                if (!vehicle.Refuel(fuelQuantity))
                {
                    Console.WriteLine($"Cannot fit {fuelQuantity} fuel in the tank");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintInfo(string id, Dictionary<string, IVehicle> vehicles)
        {
            Console.WriteLine($"{id}: {vehicles[id].FuelQuantity:F2}");
        }
    }
}
