using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Console.WriteLine($"Class under investigation: {className}");

            var type = Type.GetType(className);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var searchedFields = fields
                .Where(f => fieldNames.Contains(f.Name))
                .ToList();

            var instance = Activator.CreateInstance(type);
            var result = new StringBuilder();

            foreach (var field in searchedFields)
            {
                var value = field.GetValue(instance);
                result.AppendLine($"{field.Name} = {value}");
            }

            return result.ToString();
        }
    }
}
