using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private readonly List<Player> players;
        private string name;
        private int rating;

        public Team(string name)
        {
            players = new List<Player>();
            this.name = name;
        }

        public List<Player> Players
        {
            get
            {
                return players;
            }
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(players.Average(p => p.OverallSkillLevel));
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            if (!players.Contains(player))
            {
                throw new ArgumentException($"Player {player.Name} is not in {Name} team.");
            }

            players.Remove(player);
        }
    }
}
