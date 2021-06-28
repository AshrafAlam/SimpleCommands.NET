using System.IO;
using System.Linq;
using ShapeCreator.Core;
using ShapeCreator.Core.Command;
using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.IO;

namespace ShapeCreator.Tests.TestHelpers
{
    public static class CanvasTestHelpers
    {
        public static string ReadFromFile(string dataFilePath)
        {
            var fileText = File.ReadAllText(TestDataPaths.DefaultTestDataFolderPath + "\\" + dataFilePath);
            return fileText;
        }

            public static void Draw(this Canvas canvas, char[] line, int lineNo)
        {
            var drawingArea = canvas.GetDrawingArea();
            drawingArea[lineNo] = line;
        }

        public static Canvas BuildCanvasFromFile(string dataFilePath)
        {
            var canvasHeight = File.ReadLines(TestDataPaths.DefaultTestDataFolderPath + "\\" + dataFilePath).Count() - CanvasOffset.RowBorderOffset;

            using (var canvasContentStreamReader = TestDataReader.LoadAsReader(dataFilePath))
            {
                string line = canvasContentStreamReader.ReadLine();
                int canvasWidth = 0;
                if (line != null)
                    canvasWidth = line.Length;

                canvasWidth -= CanvasOffset.ColumnBorderOffset;

                Canvas target = new Canvas(new CartesianPoint(canvasWidth, canvasHeight), new DummayOutput());
                int lineCounter = 0;

                do
                    if (line != null) target.Draw(line.ToCharArray(), lineCounter++); while (
                    (line = canvasContentStreamReader.ReadLine()) != null);


                return target;
            }
        }

        public static bool IsEquals(this Canvas firstCanvas, Canvas secondCanvasToCompareWith)
        {
            var firstCanvasBoundary = firstCanvas.GetCanvasBoundary();
            var secondCanvasBoundary = secondCanvasToCompareWith.GetCanvasBoundary();

            if (firstCanvasBoundary.XCordinate != secondCanvasBoundary.XCordinate ||
                firstCanvasBoundary.YCordinate != secondCanvasBoundary.YCordinate)
                return false;

            var firstCanvasDrawingArea = firstCanvas.GetDrawingArea();
            var secondCanvasDrawingArea = secondCanvasToCompareWith.GetDrawingArea();

            for (int rowIteratorCount = 0; rowIteratorCount < firstCanvasBoundary.YCordinate; rowIteratorCount++)
            {
                for (int columnIteratorCount = 0;
                    columnIteratorCount < firstCanvasBoundary.XCordinate;
                    columnIteratorCount++)

                {
                    if (firstCanvasDrawingArea[rowIteratorCount][columnIteratorCount] !=
                        secondCanvasDrawingArea[rowIteratorCount][columnIteratorCount])
                        return false;

                }
            }

            return true;
        }

        public static bool IsEquals(this PixelChar firstPixelChar, PixelChar secondPixelCharToCompareWith)
        {
            return firstPixelChar.CharVal == secondPixelCharToCompareWith.CharVal;
        }

        static char[][] GetDrawingArea(this Canvas canvas)
        {
            return PrivateMemberAccessor.Factory(canvas, "DrawingArea").GetProperty<char[][]>();
        }

        static CartesianPoint GetCanvasBoundary(this Canvas canvas)
        {
            return PrivateMemberAccessor.Factory(canvas, "CanvasBoundary").GetProperty<CartesianPoint>();
        }

        internal static Canvas GetCanvas(this CommandStreamProcessor canvasCommandStreamProcessor)
        {
            var canvasCommandHandler = PrivateMemberAccessor.Factory(canvasCommandStreamProcessor, "CanvasCommandHandler").GetProperty<CommandHandler>();
            var canvas = PrivateMemberAccessor.Factory(canvasCommandHandler, "Canvas").GetProperty<Canvas>();
            return canvas;
        }

        internal static IOutput GetOutput(this CommandStreamProcessor canvasCommandStreamProcessor)
        {
            var output = PrivateMemberAccessor.Factory(canvasCommandStreamProcessor, "_output").GetField<IOutput>();
            return output;
        }
    }
}