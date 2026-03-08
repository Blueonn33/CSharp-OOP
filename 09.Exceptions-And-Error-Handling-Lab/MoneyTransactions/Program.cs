var bankAccountsData = Console.ReadLine().Split(",");
var bankAccounts = new Dictionary<int, double>();

foreach (var bankAccountData in bankAccountsData)
{
    var parts = bankAccountData.Split("-");
    var accountNumber = int.Parse(parts[0]);
    var accountBalance = double.Parse(parts[1]);

    bankAccounts[accountNumber] = accountBalance;
}

while (true)
{
    try
    {
        var command = Console.ReadLine();

        if (command == "End")
        {
            break;
        }

        var commandParts = command.Split();

        var commandName = commandParts[0];
        var accountNumber = int.Parse(commandParts[1]);
        var sum = double.Parse(commandParts[2]);

        if (commandName == "Deposit")
        {
            bankAccounts[accountNumber] += sum;
        }
        else if (commandName == "Withdraw")
        {
            if (bankAccounts[accountNumber] < sum)
            {
                throw new Exception("Insufficient balance!");
            }

            bankAccounts[accountNumber] -= sum;
        }
        else
        {
            throw new Exception("Invalid command!");
        }

        Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:F2}");
    }

    catch (KeyNotFoundException)
    {
        Console.WriteLine("Invalid account!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("Enter another command");
}