namespace ShapeCreator.Core.Exceptions
{
    public class InvalidLineDimensionException: DrawingException
    {
        public InvalidLineDimensionException():base("InvalidLineDimension. A line dimension requires either upper and lower Y or X coordinates to be matched.")
        { }

    }
}