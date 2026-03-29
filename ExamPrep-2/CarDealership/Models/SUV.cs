namespace CarDealership.Models
{
    public class SUV : Vehicle
    {
        private const double SUVPriceIncrease = 1.20;

        public SUV(string model, double price) : base(model, price * SUVPriceIncrease)
        {
        }
    }
}
