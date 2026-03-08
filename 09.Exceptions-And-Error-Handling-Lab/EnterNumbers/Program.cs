var allNumbers = new List<int>();
var startNumber = 1;

while (true)
{
    try
    {
        var number = ReadNumber(startNumber, 100);
        allNumbers.Add(number);
        startNumber = number;
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid Number!");
        continue;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    if (allNumbers.Count == 10)
    {
        break;
    }
}

Console.WriteLine(string.Join(", ", allNumbers));

static int ReadNumber(int start, int end)
{
    int number = int.Parse(Console.ReadLine());

    if (number <= start || number >= end)
    {
        throw new Exception($"Your number is not in range {start} - {end}!");
    }

    return number;
}

