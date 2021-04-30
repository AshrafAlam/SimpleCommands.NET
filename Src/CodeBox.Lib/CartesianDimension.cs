using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core
{
    public class CartesianDimension
    {
        public CartesianDimension(CartesianPoint upperLeftPoint, CartesianPoint lowerRightPoint)
        {
            _upperLeftPoint = upperLeftPoint;
            _lowerRightPoint = lowerRightPoint;
        }

        readonly CartesianPoint _upperLeftPoint;

        public CartesianPoint UpperLeftPoint
        {
            get
            {
                if (_upperLeftPoint.XCordinate > _lowerRightPoint.XCordinate)
                    ExceptionThrower.Throws<InvalidCartesianDimensionValueForXCordinateException>();
                return _upperLeftPoint;
            }
        }

        private readonly CartesianPoint _lowerRightPoint;

        public CartesianPoint LowerRightPoint
        {
            get
            {
                if (_upperLeftPoint.YCordinate > _lowerRightPoint.YCordinate)
                    ExceptionThrower.Throws<InvalidCartesianDimensionValueForYCordinateException>();

                return _lowerRightPoint;
            }
        }
        
    }
}