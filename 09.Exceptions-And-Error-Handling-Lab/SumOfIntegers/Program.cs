namespace SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine()
                .Split(" ");

            int sum = 0;

            foreach (var item in data)
            {
                try
                {
                    var element = int.Parse(item);
                    sum += element;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                }

                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
