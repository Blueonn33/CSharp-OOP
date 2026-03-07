namespace Vehicles
{
    public abstract class BaseVehicle : IVehicle
    {
        protected BaseVehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity < 0)
            {
                throw new ArgumentException("Initial fuel quantity cannot be a negative number.");
            }

            if (fuelConsumption < 0)
            {
                throw new ArgumentException("Fuel consumption cannot be a negative number.");
            }

            if (tankCapacity < 0)
            {
                throw new ArgumentException("Tank capacity cannot be a negative number.");
            }

            FuelQuantity = fuelQuantity <= tankCapacity ? fuelQuantity : 0;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
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

        public double TankCapacity
        {
            get;
        }

        protected virtual double AirConditionerIncrease
        {
            get;
        }

        protected virtual bool CanTurnAirConditionerOff { get; } = false;

        protected virtual double RefuelMultiplier { get; } = 1;

        public bool Drive(double distanceKm, IVehicle.DriveOptions? options)
        {
            if (distanceKm < 0)
            {
                throw new ArgumentException("Distance cannot be a negative number.");
            }

            double actualConsumption = this.FuelConsumption;

            if (options is not null && options.UseAirConditioner)
            {
                actualConsumption += AirConditionerIncrease;
            }

            // (FuelConsumption + 0.9) * distance
            double neededFuel = actualConsumption * distanceKm;

            if (neededFuel > this.FuelQuantity)
            {
                return false;
            }

            this.FuelQuantity -= neededFuel;

            return true;
        }

        public bool Refuel(double fuelQuantity)
        {
            if (fuelQuantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double availableTankSpace = TankCapacity - FuelQuantity;
            double amountToRefuel = fuelQuantity * this.RefuelMultiplier;

            if (amountToRefuel > availableTankSpace)
            {
                return false;
            }

            // FuelQuantity + fuelQuantity * 0.95
            this.FuelQuantity += amountToRefuel;
            return true;
        }
    }
}
