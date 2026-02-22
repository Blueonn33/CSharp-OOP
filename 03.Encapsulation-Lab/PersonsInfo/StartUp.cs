using System.Threading.Channels;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var firstName = input[0];
                var lastName = input[1];
                var age = int.Parse(input[2]);
                var salary = decimal.Parse(input[3]);

                Person person = new Person(firstName, lastName, age, salary);
                people.Add(person);
            }

            var percentage = decimal.Parse(Console.ReadLine());

            people.ForEach(p => p.IncreaseSalary(percentage));
            people.OrderBy(p => p.FirstName)
                  .ThenBy(p => p.Age)
                  .ToList()
                  .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
