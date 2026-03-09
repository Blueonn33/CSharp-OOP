List<int> numbers = ReadNumbers();

//Console.WriteLine(string.Join(", ", ManipulateNumbers(numbers)));
PrintNumberSquare(numbers);

static List<int> ManipulateNumbers(List<int> numbers)
{
    var result = new List<int>();

    foreach (var number in numbers)
    {
        result.Add(number * number);
    }

    return result;
}

static List<int> ReadNumbers()
{
    return Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToList();
}

static void PrintNumberSquare(List<int> numbers)
{
    foreach (var number in numbers)
    {
        Console.WriteLine(number * number);
    }
}