using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var allTypes = Assembly.GetCallingAssembly().GetTypes();

            foreach (var type in allTypes)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

                foreach (var method in methods)
                {
                    var authorAttribute = type
                        .GetCustomAttributes<AuthorAttribute>()
                        .Select(attr => attr.Name)
                        .ToList();

                    if (authorAttribute.Any())
                    {
                        Console.WriteLine($"{method.Name} is written by {string.Join(", ", authorAttribute)}");
                    }
                }
            }
        }
    }
}
