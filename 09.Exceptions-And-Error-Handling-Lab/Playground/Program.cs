namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            try
            {
                var number = int.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number.");
            }

            Console.WriteLine("Ok");
        }
    }
}
