namespace PlayCatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var totalExceptions = 0;

            while (true)
            {
                if (totalExceptions == 3)
                {
                    break;
                }

                try
                {
                    string command = Console.ReadLine();
                    var commandParts = command.Split();

                    if (commandParts[0] == "Replace")
                    {
                        var index = int.Parse(commandParts[1]);
                        var element = int.Parse(commandParts[2]);

                        numbers[index] = element;
                    }
                    else if (commandParts[0] == "Print")
                    {
                        var startIndex = int.Parse(commandParts[1]);
                        var endIndex = int.Parse(commandParts[2]);
                        var result = new List<int>();

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            result.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", result));
                    }
                    else if (commandParts[0] == "Show")
                    {
                        var index = int.Parse(commandParts[1]);

                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    totalExceptions++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    totalExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
