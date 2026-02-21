namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(100, 200);
                Console.WriteLine(vehicle.HorsePower);
                Console.WriteLine(vehicle.Fuel);
                Console.WriteLine(vehicle.FuelConsumption);
                vehicle.Drive(100);
                Console.WriteLine(vehicle.Fuel);
        }
    }
}
