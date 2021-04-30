namespace ShapeCreator.Core.DrawingObjects
{
    public class BucketFillObject : DrawingObject
    {
        private readonly CartesianPoint _bucketFillPoint;

        public BucketFillObject(CartesianPoint bucketFillPoint, Canvas canvas, PixelChar pixelChar = null) : base(
            canvas,
            pixelChar)
        {
            _bucketFillPoint = bucketFillPoint;
        }

        public override void Draw()
        {
            BucketFill(_bucketFillPoint);
        }

        void BucketFill(CartesianPoint bucketFillPoint)
        {
            var bfChar = Canvas.GetPixel(bucketFillPoint).CharVal;

            if (bfChar != DrawingChars.BlankSpaceChar)
                return;

            Canvas.DrawPixel(PixelChar, bucketFillPoint);

            if (bucketFillPoint.XCordinate < Canvas.CanvasBoundary.XCordinate)
                BucketFill(new CartesianPoint(bucketFillPoint.XCordinate + 1, bucketFillPoint.YCordinate));

            if (bucketFillPoint.YCordinate < Canvas.CanvasBoundary.YCordinate)
                BucketFill(new CartesianPoint(bucketFillPoint.XCordinate, bucketFillPoint.YCordinate + 1));

            if (bucketFillPoint.XCordinate > CanvasOffset.ColumnBorderOffset - 1)
                BucketFill(new CartesianPoint(bucketFillPoint.XCordinate - 1, bucketFillPoint.YCordinate));

            if (bucketFillPoint.YCordinate > CanvasOffset.RowBorderOffset - 1)
                BucketFill(new CartesianPoint(bucketFillPoint.XCordinate, bucketFillPoint.YCordinate - 1));

        }
    }
}