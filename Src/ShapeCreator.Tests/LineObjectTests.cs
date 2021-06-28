using ShapeCreator.Core;
using ShapeCreator.Core.Exceptions;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;

namespace ShapeCreator.Tests
{
    public class LineObjectTests : CanvasTestbase
    {
        public LineObjectTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void DrawLine_1x1HorizontalLineOn1x1Canvas_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(OnePixelFilledCanvasFilePath);
            int canvasWidth = 1, canvasHeight = 1;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);
            int upperLeftXForLine = 1, upperLeftYForLine = 1, lowerLeftXForLine = 1, lowerRightYForLine = 1;
            var lineObject = Factory_LineObject(upperLeftXForLine, upperLeftYForLine, lowerLeftXForLine,
                lowerRightYForLine,
                actualCanvas);

            //Act
            lineObject.Draw();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void DrawLine_1HorizontalLineOnCanvas_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(Canvas20X4With1LineFilePath);
            int canvasWidth = 20, canvasHeight = 4;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);
            int upperLeftXForLine = 1, upperLeftYForLine = 2, lowerLeftXForLine = 6, lowerRightYForLine = 2;
            var lineObject = Factory_LineObject(upperLeftXForLine, upperLeftYForLine, lowerLeftXForLine,
                lowerRightYForLine,
                actualCanvas);

            //Act
            lineObject.Draw();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void DrawLine_1Horizontal1VirtialLineOnCanvas_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(Canvas20X4With2LinesFilePath);
            int canvasWidth = 20, canvasHeight = 4;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);
            int upperLeftXForHorizontalLine = 1,
                upperLeftYForHorizontalLine = 2,
                lowerLeftXForHorizontalLine = 6,
                lowerRightYForHorizontalLine = 2;
            var horizontalLineObject = Factory_LineObject(upperLeftXForHorizontalLine, upperLeftYForHorizontalLine,
                lowerLeftXForHorizontalLine, lowerRightYForHorizontalLine,
                actualCanvas);

            int upperLeftXForVirticalLine = 6,
                upperLeftYForVirticalLine = 3,
                lowerLeftXForVirticalLine = 6,
                lowerRightYForVirticalLine = 4;
            var virticalLineObject = Factory_LineObject(upperLeftXForVirticalLine, upperLeftYForVirticalLine,
                lowerLeftXForVirticalLine, lowerRightYForVirticalLine,
                actualCanvas);

            //Act
            horizontalLineObject.Draw();
            virticalLineObject.Draw();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void DrawLine_InvalidLineDimensionProvided_ShouldThrowException()
        {
            //Arrange
            int canvasWidth = 20, canvasHeight = 4;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);
            int upperLeftXForLine = 1, upperLeftYForLine = 2, lowerLeftXForLine = 3, lowerRightYForLine = 4;
            var lineObject = Factory_LineObject(upperLeftXForLine, upperLeftYForLine, lowerLeftXForLine,
                lowerRightYForLine,
                actualCanvas);

            //Act + Assert
            ExpectedExceptionHelpers.ExpectExceptionType<InvalidLineDimensionException>(() =>
                lineObject.Draw());
        }
    }
}
