using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string input)
        {
            string[] args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = args[0];
            string[] commandArgs = args[1..];

            Type type = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            ICommand command = (ICommand)Activator.CreateInstance(type);

            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
