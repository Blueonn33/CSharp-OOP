public class Card
{
    private static string[] validFaces = new string[]
    {
        "2", "3", "4", "5","6","7", "8", "9", "10","J","Q", "K", "A"
    };
    private static string[] validSuits = new string[]
    {
        "S", "H", "D", "C"
    };

    public Card(string face, string suit)
    {
        this.ValidateFace(face);
        this.ValidateSuit(suit);

        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get; private set;
    }
    public string Suit
    {
        get; private set;
    }

    public override string ToString()
    {
        var suitSymbol = "";

        switch (this.Suit)
        {
            case "S":
                suitSymbol = "\u2660";
                break;
            case "H":
                suitSymbol = "\u2665";
                break;
            case "D":
                suitSymbol = "\u2666";
                break;
            case "C":
                suitSymbol = "\u2663";
                break;
        }

        return $"[{this.Face}{suitSymbol}]";
    }

    private void ValidateFace(string face)
    {
        if (!validFaces.Contains(face))
        {
            throw new Exception("Invalid card!");
        }
    }

    private void ValidateSuit(string suit)
    {
        if (!validSuits.Contains(suit))
        {
            throw new Exception("Invalid card!");
        }
    }
}

public class Program
{
    public static void Main()
    {
        var cards = Console.ReadLine()
            .Split(",", StringSplitOptions.RemoveEmptyEntries);

        var cardsList = new List<Card>();

        foreach (var item in cards)
        {
            var parts = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var face = parts[0];
            var suit = parts[1];

            try
            {
                var card = new Card(face, suit);
                cardsList.Add(card);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(string.Join(" ", cardsList));
    }
}