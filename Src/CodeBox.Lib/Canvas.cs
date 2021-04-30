using ShapeCreator.Core.Exceptions;
using ShapeCreator.Core.IO;

namespace ShapeCreator.Core
{
    public class Canvas
    {
        public Canvas(CartesianPoint canvasBoundary, IOutput output)
        {
            CanvasBoundary = canvasBoundary;
            _output = output;
        }

        public CartesianPoint CanvasBoundary { get; }

        private char[][] _drawingArea;
        private char[][] DrawingArea => _drawingArea ?? (_drawingArea = DrawingAreaFactory(CanvasBoundary));
        private static char[][] DrawingAreaFactory(CartesianPoint canvasBoundary)
        {
            var drawingArea = new char[canvasBoundary.YCordinate + CanvasOffset.RowBorderOffset][];

            for (int rowIteratorCount = 0;
                rowIteratorCount < canvasBoundary.YCordinate + CanvasOffset.RowBorderOffset;
                rowIteratorCount++)
            {
                drawingArea[rowIteratorCount] = new char[canvasBoundary.XCordinate + CanvasOffset.ColumnBorderOffset];

                for (int columnIteratorCount = 0;
                    columnIteratorCount < canvasBoundary.XCordinate + CanvasOffset.ColumnBorderOffset;
                    columnIteratorCount++)
                {
                    char targetPixelChar;

                    if (rowIteratorCount == 0 ||
                        rowIteratorCount == canvasBoundary.YCordinate + CanvasOffset.RowBorderOffset - 1)
                        targetPixelChar = DrawingChars.HorizontalCanvasBorderChar;
                    else if (columnIteratorCount == 0 ||
                             columnIteratorCount == canvasBoundary.XCordinate + CanvasOffset.ColumnBorderOffset - 1)
                        targetPixelChar = DrawingChars.VirticalCanvasBorderChar;
                    else
                        targetPixelChar = DrawingChars.BlankSpaceChar;

                    drawingArea[rowIteratorCount][columnIteratorCount] = targetPixelChar;
                }
            }

            return drawingArea;

        }

        private readonly IOutput _output;
        
        public void DrawPixel(PixelChar pixelChar, CartesianPoint pointLocation)
        {
            ValidatePointBoundary(pointLocation);

            DrawingArea[pointLocation.YCordinate][pointLocation.XCordinate] = pixelChar.CharVal;
        }

        public PixelChar GetPixel(CartesianPoint pointLocation)
        {
            ValidatePointBoundary(pointLocation);

            return new PixelChar(DrawingArea[pointLocation.YCordinate][pointLocation.XCordinate]);
        }

        void ValidatePointBoundary(CartesianPoint pointLocation)
        {
            if (pointLocation.XCordinate > CanvasBoundary.XCordinate)
                throw new XCoordinateExceedsCanvasBoundaryException(pointLocation.XCordinate, CanvasBoundary.XCordinate);

            if (pointLocation.YCordinate > CanvasBoundary.YCordinate)
                throw new YCoordinateExceedsCanvasBoundaryException(pointLocation.YCordinate, CanvasBoundary.YCordinate);

        }

        public void Render()
        {
            for (int rowIteratorCount = 0;
                rowIteratorCount < CanvasBoundary.YCordinate + CanvasOffset.RowBorderOffset;
                rowIteratorCount++)
                _output.WriteLine(DrawingArea[rowIteratorCount]);
        }
    }
}