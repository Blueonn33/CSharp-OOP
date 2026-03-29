namespace CarDealership.Models
{
    public class Truck : Vehicle
    {
        private const double TruckPriceIncrease = 1.30;
        public Truck(string model, double price) : base(model, price * TruckPriceIncrease)
        {
        }
    }
}
