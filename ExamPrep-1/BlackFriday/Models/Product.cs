using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        private string productName;
        private double basePrice;

        public string ProductName
        {
            get => this.productName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ProductNameRequired);
                }

                this.productName = value;
            }
        }
        public double BasePrice
        {
            get => basePrice;
            private set
            {
                // If the property is mutable, prefer validations within the `set` accessor

                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
                }

                basePrice = value;
            }
        }
        public virtual double BlackFridayPrice
        {
            get;
        }
        public bool IsSold
        {
            get;
            private set;
        }

        protected Product(string productName, double basePrice)
        {
            // I prefer validations directly within the constructor.
            // This idea is applicable for immutable properties only.

            ProductName = productName;
            BasePrice = basePrice;
        }

        public void UpdatePrice(double newPriceValue)
        {
            BasePrice = newPriceValue;
        }

        public void ToggleStatus()
        {
            IsSold = !IsSold;
        }

        public override string ToString()
        {
            return $"Product: {ProductName}, Price: {BasePrice:F2}, You Save: {(BasePrice - BlackFridayPrice):F2}";
        }
    }
}
