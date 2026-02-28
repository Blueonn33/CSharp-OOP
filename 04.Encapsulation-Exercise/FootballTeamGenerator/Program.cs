using FootballTeamGenerator.Models;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string teamName = commandArgs[1];
                try
                {
                    if (command == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(teamName, team);
                    }
                    else if (command == "Add")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        string playerName = commandArgs[2];
                        int endurance = int.Parse(commandArgs[3]);
                        int sprint = int.Parse(commandArgs[4]);
                        int dribble = int.Parse(commandArgs[5]);
                        int passing = int.Parse(commandArgs[6]);
                        int shooting = int.Parse(commandArgs[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[teamName].AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        string playerName = commandArgs[2];
                        Player playerToRemove = teams[teamName].Players.FirstOrDefault(p => p.Name == playerName);
                        if (playerToRemove == null)
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                            continue;
                        }

                        teams[teamName].RemovePlayer(playerToRemove);
                    }
                    else if (command == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
