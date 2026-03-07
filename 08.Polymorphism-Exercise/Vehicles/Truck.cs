namespace Vehicles
{
    public class Truck : BaseVehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double FuelConsumptionIncrease { get; } = 1.6;

        protected override double RefuelMultiplier { get; } = 0.95;
    }
}
