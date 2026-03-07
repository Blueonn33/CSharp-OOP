namespace Vehicles
{
    public abstract class BaseVehicle : IVehicle
    {
        protected BaseVehicle(double fuelQuantity, double fuelConsumption)
        {
            if (fuelQuantity < 0)
            {
                throw new ArgumentException("Initial fuel quantity cannot be a negative number.");
            }

            if (fuelConsumption < 0)
            {
                throw new ArgumentException("Fuel consumption cannot be a negative number.");
            }

            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get;
            private set;
        }
        public double FuelConsumption
        {
            get;
        }

        protected virtual double FuelConsumptionIncrease
        {
            get;
        }

        protected virtual double RefuelMultiplier { get; } = 1;

        public bool Drive(double distanceKm)
        {
            if (distanceKm < 0)
            {
                throw new ArgumentException("Distance cannot be a negative number.");
            }

            // (FuelConsumption + 0.9) * distance
            double neededFuel = (this.FuelConsumption + this.FuelConsumptionIncrease) * distanceKm;

            if (neededFuel > this.FuelQuantity)
            {
                return false;
            }

            this.FuelQuantity -= neededFuel;

            return true;
        }

        public void Refuel(double fuelQuantity)
        {
            if (fuelQuantity < 0)
            {
                throw new ArgumentException("Fuel quantity cannot be a negative number.");
            }

            // FuelQuantity + fuelQuantity * 0.95
            this.FuelQuantity += fuelQuantity * this.RefuelMultiplier;
        }
    }
}
