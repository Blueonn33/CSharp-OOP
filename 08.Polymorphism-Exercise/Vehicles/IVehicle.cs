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


        // double distanceKm = 3.31;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="distanceKm"> The distance to drive
        /// (in kilometers)</param>
        public bool Drive(double distanceKm);
        public void Refuel(double fuelQuantity);
    }
}
