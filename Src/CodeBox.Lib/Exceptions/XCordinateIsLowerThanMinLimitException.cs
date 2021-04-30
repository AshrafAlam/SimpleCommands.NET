namespace ShapeCreator.Core.Exceptions
{
    public class XCordinateIsLowerThanMinLimitException : DrawingException
    {
        public XCordinateIsLowerThanMinLimitException() : base("XCordinate is lower than min limit.")
        {
            
        }
    }
}