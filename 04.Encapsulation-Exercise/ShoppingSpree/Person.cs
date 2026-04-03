namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
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
        public decimal Money
        {
            get => money;
            set
            {
                if (value >= 0)
                {
                    money = value;
                }
                else
                {
                    throw new ArgumentException("Money cannot be negative");
                }
            }
        }

        public List<Product> Products
        {
            get; set;
        }
    }
}
