using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private double endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public double Sprint
        {
            get => sprint;
            private set => sprint = ValidateStat((int)value, nameof(Sprint));
        }
        public double Dribble
        {
            get => dribble;
            private set => dribble = ValidateStat((int)value, nameof(Dribble));
        }
        public double Passing
        {
            get => passing;
            private set => passing = ValidateStat((int)value, nameof(Passing));
        }
        public double Shooting
        {
            get => shooting;
            private set => shooting = ValidateStat((int)value, nameof(Shooting));
        }
        public double Endurance
        {
            get => endurance;
            private set => endurance = ValidateStat((int)value, nameof(Endurance));
        }
        public double OverallSkillLevel => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        private int ValidateStat(int value, string statName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
            return value;
        }
    }
}
