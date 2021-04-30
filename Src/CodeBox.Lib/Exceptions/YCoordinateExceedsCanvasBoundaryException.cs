namespace ShapeCreator.Core.Exceptions
{
    public class YCoordinateExceedsCanvasBoundaryException : DrawingException
    {
        public YCoordinateExceedsCanvasBoundaryException(int givenYCoordinate, int canvasBoundryY)
            : base($"Invalid y coordinate provided. Given Y: {givenYCoordinate}, Canvas boundary Y: {canvasBoundryY}")
        {
            
        }
    }
}