using System.Linq;

namespace SimpleCommands.Core.Command.Infrastructure
{
    public static class CommandArgParser
    {
        public static CommandValues ParseToCommandValues(string commandLine)
        {
            var parts = commandLine.Split(' ').ToList();
            string commandName = parts[0];
            parts.RemoveAt(0);

            string[] commandArgs = parts.ToArray<string>();

            return new CommandValues
            {
                CommandName = commandName,
                CommandArgs = commandArgs
            };
        }
    }
}