namespace Vehicles
{
    public class Bus : BaseVehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AirConditionerIncrease { get; } = 1.4;
    }
}
