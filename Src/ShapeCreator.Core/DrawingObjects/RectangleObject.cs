namespace ShapeCreator.Core.DrawingObjects
{
    public class RectangleObject : DrawingObject
    {
        private readonly CartesianDimension _rectangleDimension;

        public RectangleObject(CartesianDimension rectangleDimension, Canvas canvas, PixelChar pixelChar = null) : base(canvas,
            pixelChar)
        {
            _rectangleDimension = rectangleDimension;
        }

        public override void Draw()
        {
            for (int rowIteratorCount = _rectangleDimension.UpperLeftPoint.YCordinate;
                rowIteratorCount <= _rectangleDimension.LowerRightPoint.YCordinate;
                rowIteratorCount++)
            {
                
                for (int columnIteratorCount = _rectangleDimension.UpperLeftPoint.XCordinate;
                    columnIteratorCount <= _rectangleDimension.LowerRightPoint.XCordinate;
                    columnIteratorCount++)
                {
                    if (rowIteratorCount == _rectangleDimension.UpperLeftPoint.YCordinate ||
                        rowIteratorCount == _rectangleDimension.LowerRightPoint.YCordinate ||
                        columnIteratorCount == _rectangleDimension.UpperLeftPoint.XCordinate ||
                        columnIteratorCount == _rectangleDimension.LowerRightPoint.XCordinate)
                        Canvas.DrawPixel(PixelChar, new CartesianPoint(columnIteratorCount, rowIteratorCount));
                }
            }
        }
    }
}