namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty");
                Environment.Exit(0);
            }

            if (money < 0)
            {
                Console.WriteLine("Money cannot be negative");
                Environment.Exit(0);
            }

            this.name = name;
            this.money = money;
            Products = new List<Product>();
        }

        public string Name => name;

        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }

                money = value;
            }
        }

        public List<Product> Products
        {
            get;
        }
    }
}