namespace ShapeCreator.Core.Exceptions
{
    public class InvalidCommandArgumentLengthException : DrawingException
    {
        public InvalidCommandArgumentLengthException(int expectedCommandArgumentLength) :
            base($"Invalid command argument length. Expected length {expectedCommandArgumentLength}")
        {
            
        }
    }
}