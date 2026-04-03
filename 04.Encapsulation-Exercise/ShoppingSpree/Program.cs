namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();
            List<Product> products = new();

            string[] readPeopleData = Console.ReadLine().Split(";");
            string[] readProductsData = Console.ReadLine().Split(";");

            foreach (var person in readPeopleData)
            {
                string[] personData = person.Split("=");
                string personName = personData[0];
                decimal money = decimal.Parse(personData[1]);

                Person personObj = new Person(personName, money);
                people.Add(personObj);
            }

            foreach (var product in readProductsData)
            {
                string[] productData = product.Split("=");
                string productName = productData[0];
                decimal money = decimal.Parse(productData[1]);

                Product productObj = new Product(productName, money);
                products.Add(productObj);
            }


        }
    }
}
