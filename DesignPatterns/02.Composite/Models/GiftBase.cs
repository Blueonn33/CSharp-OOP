namespace _02.Composite.Models
{
    public abstract class GiftBase
    {
        private string name;
        private decimal price;

        public GiftBase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        protected string Name
        {
            get => name;
            private set => name = value;
        }
        protected decimal Price
        {
            get => price;
            private set => price = value;
        }

        public abstract decimal CalculateTotalPrice();
    }
}
