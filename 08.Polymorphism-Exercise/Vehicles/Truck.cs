namespace Vehicles
{
    public class Truck : BaseVehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AirConditionerIncrease { get; } = 1.6;

        protected override double RefuelMultiplier { get; } = 0.95;
    }
}
