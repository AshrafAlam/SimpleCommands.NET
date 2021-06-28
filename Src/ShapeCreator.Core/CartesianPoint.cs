using ShapeCreator.Core.Exceptions;
using static ShapeCreator.Core.ExceptionThrower;

namespace ShapeCreator.Core
{
    public class CartesianPoint
    {
        public CartesianPoint(int xCordinate, int yCordinate)
        {
            _xCordinate = xCordinate;
            _yCorninate = yCordinate;
        }

        private readonly int _xCordinate;

        public int XCordinate
        {
            get
            {
                if (_xCordinate < XCordinateMinValue)
                    Throws<XCordinateIsLowerThanMinLimitException>();

                return _xCordinate;
            }
        }

        private readonly int _yCorninate;

        public int YCordinate
        {
            get
            {
                if (_yCorninate < YCordinateMinValue)
                    Throws<YCordinateIsLowerThanMinLimitException>();

                return _yCorninate;
            }
        }

        private const int XCordinateMinValue = 1;
        private const int YCordinateMinValue = 1;

    }
}