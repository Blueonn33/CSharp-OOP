namespace ShoppingSpree
{
    public class Product
    {
        // Each product should have a name and a cost. The name cannot be an empty string or whitespace. Money and cost cannot be negative numbers.

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
