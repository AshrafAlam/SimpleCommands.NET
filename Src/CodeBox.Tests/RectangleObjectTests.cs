using ShapeCreator.Core;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;

namespace ShapeCreator.Tests
{
    public class RectangleObjectTests : CommandTestbase
    {
        public RectangleObjectTests(ITestOutputHelper output):base(output)
        {
            
        }

        [Fact]
        public void DrawRectangle_1x1RectangleOn1x1Canvas_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(OnePixelFilledCanvasFilePath);
            int canvasWidth = 1, canvasHeight = 1;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);
            int upperLeftXForRectangle = 1, upperLeftYForRectangle = 1, lowerLeftXForRectangle = 1, lowerRightYForRectangle = 1;
            var rectangleObject = Factory_RectangleObject(upperLeftXForRectangle, upperLeftYForRectangle, lowerLeftXForRectangle, lowerRightYForRectangle,
                actualCanvas);

            //Act
            rectangleObject.Draw();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void DrawRectangle_1RectangleOnCanvas_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(Canvas20X4With1RectangleFilePath);
            int canvasWidth = 20, canvasHeight = 4;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);
            int upperLeftXForRectangle = 14, upperLeftYForRectangle = 1, lowerLeftXForRectangle = 18, lowerRightYForRectangle = 3;
            var rectangleObject = Factory_RectangleObject(upperLeftXForRectangle, upperLeftYForRectangle, lowerLeftXForRectangle, lowerRightYForRectangle,
                actualCanvas);

            //Act
            rectangleObject.Draw();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }
    }
}
