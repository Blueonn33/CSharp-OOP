namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity
        {
            get;
        }

        /// <summary>
        /// Fuel consumption in liters per kilometer
        /// </summary>
        public double FuelConsumption
        {
            get;
        }
        double TankCapacity
        {
            get;
        }

        // double distanceKm = 3.31;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="distanceKm"> The distance to drive
        /// (in kilometers)</param>
        public bool Drive(double distanceKm, DriveOptions? options = null);

        public bool Refuel(double fuelQuantity);

        public sealed class DriveOptions
        {
            public bool UseAirConditioner
            {
                get;
                init;
            } = true;
        }
    }
}
