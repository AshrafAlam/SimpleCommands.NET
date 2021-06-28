namespace ShapeCreator.Core.Exceptions
{
    public class InvalidCommandException : DrawingException
    {
        public InvalidCommandException(string commandName):base(
            $"Invlid command name provided. Command name: {commandName}.")
        {
            
        }

    }
}