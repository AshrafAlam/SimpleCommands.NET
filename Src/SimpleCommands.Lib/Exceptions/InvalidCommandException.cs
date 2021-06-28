namespace SimpleCommands.Core.Exceptions
{
    public class InvalidCommandException : CommandException
    {
        public InvalidCommandException(string commandName):base(
            $"Invlid command name provided. Command name: {commandName}.")
        {
            
        }

    }
}