namespace ShapeCreator.Core.Exceptions
{
    public class XCoordinateExceedsCanvasBoundaryException : DrawingException
    {
        public XCoordinateExceedsCanvasBoundaryException(int givenXCoordinate, int canvasBoundryX)
            : base($"Invalid x coordinate provided. Given X: {givenXCoordinate}, Canvas boundary X: {canvasBoundryX}")
        {
            
        }
    }
}