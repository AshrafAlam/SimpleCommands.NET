using ShapeCreator.Core;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;

namespace ShapeCreator.Tests
{
    public class CanvasCreationTests : CanvasTestbase
    {

        public CanvasCreationTests(ITestOutputHelper output):base(output)
        {
            
        }

        [Fact]
        public void CreateCanvas_Create1x1SquareCanvas_ShouldCreateBlankCanvas()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(OnePixelSquareBlankCanvasFilePath);
            int canvasWidth = 1, canvasHeight = 1;

            //Act
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void CreateCanvas_Create20x4Canvas_ShouldCreateBlankCanvas()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(BlankCanvas20X4FilePath);
            int canvasWidth = 20, canvasHeight = 4;

            //Act
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

    }
}
