namespace Vehicles
{
    public class Car : BaseVehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        protected override double FuelConsumptionIncrease { get; } = 0.9;
    }
}
