using System.Text;

namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();
            List<Product> products = new();

            string[] readPeopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] readProductsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

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

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandInput = command.Split();
                string personName = commandInput[0];
                string productName = commandInput[1];

                Person person;
                Product product;

                person = people.FirstOrDefault(p => p.Name == personName);
                product = products.FirstOrDefault(p => p.Name == productName);

                if (person.Money >= product.Cost)
                {
                    person.Products.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                    person.Money -= product.Cost;
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }

            foreach (var person in people)
            {
                StringBuilder sb = new();
                sb.Append(person.Name);

                if (person.Products.Capacity == 0)
                {
                    sb.AppendLine($" - Nothing bought ");
                }
                else
                {
                    sb.AppendLine(string.Join(", ", person.Products));
                }
            }
        }
    }
}
