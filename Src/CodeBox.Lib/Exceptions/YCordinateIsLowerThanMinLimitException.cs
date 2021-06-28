namespace ShapeCreator.Core.Exceptions
{
    public class YCordinateIsLowerThanMinLimitException : DrawingException
    {
        public YCordinateIsLowerThanMinLimitException() : base("YCordinate is lower than min limit.")
        {
            
        }
    }
}