using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        private double _basePrice;

        public string ProductName
        {
            get;
        }
        public double BasePrice
        {
            get => this._basePrice;
            set
            {
                this._basePrice = value;
            }
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
            // I prefer validations directly within the constructor.
            // This idea is applicable for immutable properties only.

            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException(ExceptionMessages.ProductNameRequired);
            }

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
