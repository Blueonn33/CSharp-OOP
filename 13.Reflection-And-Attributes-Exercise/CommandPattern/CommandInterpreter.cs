using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string input)
        {
            string[] args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = args[0];
            string[] commandArgs = args[1..];

            return null;
        }
    }
}
