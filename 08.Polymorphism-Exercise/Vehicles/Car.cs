namespace Vehicles
{
    public class Car : BaseVehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double AirConditionerIncrease { get; } = 0.9;
    }
}
