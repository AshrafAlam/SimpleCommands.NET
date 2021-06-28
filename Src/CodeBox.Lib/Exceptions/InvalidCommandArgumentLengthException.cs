namespace CodeBox.Core.Exceptions
{
    public class InvalidCommandArgumentLengthException : CommandException
    {
        public InvalidCommandArgumentLengthException(int expectedCommandArgumentLength) :
            base($"Invalid command argument length. Expected length {expectedCommandArgumentLength}")
        {
            
        }
    }
}