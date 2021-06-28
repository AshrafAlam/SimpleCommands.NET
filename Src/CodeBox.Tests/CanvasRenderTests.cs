using ShapeCreator.Core;
using ShapeCreator.Core.Exceptions;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.ExpectedExceptionHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;

namespace ShapeCreator.Tests
{
    public class CanvasRenderTests : CommandTestbase
    {

        public CanvasRenderTests(ITestOutputHelper output):base(output)
        {
            
        }

        [Fact]
        public void Render_Create1x1SquareCanvas_ShouldCreateBlankCanvas()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(OnePixelSquareBlankCanvasFilePath);
            int canvasWidth = 1, canvasHeight = 1;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);

            //Act
            actualCanvas.Render();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void Render_Create20x4Canvas_ShouldCreateBlankCanvas()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(BlankCanvas20X4FilePath);
            int canvasWidth = 20, canvasHeight = 4;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);

            //Act
            actualCanvas.Render();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void Render_Create0x1SquareCanvas_ShouldThrowExceptionForXCordinate()
        {
            //Arrange
            int canvasWidth = 0, canvasHeight = 1;
            var canvas = Factory_Canvas(canvasWidth, canvasHeight);

            //Act + Assert
            ExpectException<XCordinateIsLowerThanMinLimitException>(() => canvas.Render());
        }

        [Fact]
        public void Render_Create0x0SquareCanvas_ShouldThrowExceptionForYCordinate()
        {
            //Arrange
            int canvasWidth = 0, canvasHeight = 0;
            var canvas = Factory_Canvas(canvasWidth, canvasHeight);

            //Act + Assert
            ExpectException<YCordinateIsLowerThanMinLimitException>(() => canvas.Render());
        }

        [Fact]
        public void Render_Create1x0Canvas_ShouldThrowExceptionForYCordinate()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 0;
            var canvas = Factory_Canvas(canvasWidth, canvasHeight);

            //Act + Assert
            ExpectException<YCordinateIsLowerThanMinLimitException>(() => canvas.Render());
        }
    }
}
