namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty");
                Environment.Exit(0);
            }

            if (cost < 0)
            {
                Console.WriteLine("Money cannot be negative");
                Environment.Exit(0);
            }

            this.name = name;
            this.cost = cost;
        }

        public string Name => name;

        public decimal Cost => cost;

        public override string ToString() => Name;
    }
}