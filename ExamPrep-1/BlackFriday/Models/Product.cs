using BlackFriday.Models.Contracts;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        public string ProductName
        {
            get;
        }
        public double BasePrice
        {
            get;
        }
        public double BlackFridayPrice
        {
            get;
        }
        public bool IsSold
        {
            get;
        }

        protected Product(string productName, double basePrice)
        {
            ProductName = productName;
            BasePrice = basePrice;
        }

        public void UpdatePrice(double newPriceValue)
        {
            throw new NotImplementedException();
        }

        public void ToggleStatus()
        {
            throw new NotImplementedException();
        }
    }
}
