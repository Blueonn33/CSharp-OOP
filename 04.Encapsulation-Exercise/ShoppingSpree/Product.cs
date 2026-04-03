namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty");
                }
            }
        }
        public decimal Cost
        {
            get => cost;
            set
            {
                if (value >= 0)
                {
                    cost = value;
                }
                else
                {
                    throw new ArgumentException("Money cannot be negative");
                }
            }
        }

    }
}
