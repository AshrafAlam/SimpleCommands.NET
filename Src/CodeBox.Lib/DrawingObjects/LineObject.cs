using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core.DrawingObjects
{
    public class LineObject : DrawingObject
    {
        private readonly CartesianDimension _lineDimension;

        public LineObject(CartesianDimension lineDimension, Canvas canvas, PixelChar pixelChar = null) : base(canvas,
            pixelChar)
        {
            _lineDimension = lineDimension;
        }

        public override void Draw()
        {
            bool isHorizontal = false;
            int start = 0, end = 0;
            if (_lineDimension.UpperLeftPoint.YCordinate == _lineDimension.LowerRightPoint.YCordinate)
            {
                isHorizontal = true;
                start = _lineDimension.UpperLeftPoint.XCordinate;
                end = _lineDimension.LowerRightPoint.XCordinate;
            }
            else if (_lineDimension.UpperLeftPoint.XCordinate == _lineDimension.LowerRightPoint.XCordinate)
            {
                start = _lineDimension.UpperLeftPoint.YCordinate;
                end = _lineDimension.LowerRightPoint.YCordinate;
            }
            else
                ExceptionThrower.Throws<InvalidLineDimensionException>();

            for (int i = start; i <= end; i++)
                Canvas.DrawPixel(PixelChar, new CartesianPoint(
                    isHorizontal ? i : _lineDimension.UpperLeftPoint.XCordinate,
                    isHorizontal ? _lineDimension.UpperLeftPoint.YCordinate : i));

        }
    }
}