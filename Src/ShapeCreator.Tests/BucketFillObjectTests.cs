using ShapeCreator.Core;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;

namespace ShapeCreator.Tests
{
    public class BucketFillObjectTests : CanvasTestbase
    {
        public BucketFillObjectTests(ITestOutputHelper output):base(output)
        {
            
        }

        [Fact]
        public void DrawBucketFill_1x1BucketFillOn1x1FilledCanvas_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(OnePixelFilledCanvasFilePath);
            int canvasWidth = 1, canvasHeight = 1;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);
            int xPointForBucketFill = 1, yPointForBucketFill = 1;
            char bucketFillColor = 'o';
            var buketFillObject = Factory_BucketFillObject(xPointForBucketFill, yPointForBucketFill,  bucketFillColor, actualCanvas);

            //Act
            buketFillObject.Draw();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void DrawBucketFill_BucketFillOn20x4CanvasWithRectangle_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(Canvas20X4With1RectangleForBucketFillingFilePath);
            int canvasWidth = 20, canvasHeight = 4;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);

            int upperLeftXForRectangle = 14, upperLeftYForRectangle = 1, lowerLeftXForRectangle = 18, lowerRightYForRectangle = 3;
            var rectangleObject = Factory_RectangleObject(upperLeftXForRectangle, upperLeftYForRectangle, lowerLeftXForRectangle, lowerRightYForRectangle,
                actualCanvas);

            rectangleObject.Draw();

            int xPointForBucketFill = 10, yPointForBucketFill = 3;
            char bucketFillColor = 'o';
            var buketFillObject = Factory_BucketFillObject(xPointForBucketFill, yPointForBucketFill, bucketFillColor, actualCanvas);

            //Act
            buketFillObject.Draw();
            actualCanvas.Render();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void DrawBucketFill_BucketFillOn20x4BlankCanvas_ShouldBeSuccessful()
        {
            //Arrange
            Canvas expectedCanvas = BuildCanvasFromFile(Canvas20X4WithFullBucketFilledFilePath);
            int canvasWidth = 20, canvasHeight = 4;
            Canvas actualCanvas = Factory_Canvas(canvasWidth, canvasHeight);

            int xPointForBucketFill = 10, yPointForBucketFill = 3;
            char bucketFillColor = 'o';
            var buketFillObject = Factory_BucketFillObject(xPointForBucketFill, yPointForBucketFill, bucketFillColor, actualCanvas);

            //Act
            buketFillObject.Draw();
            actualCanvas.Render();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }
    }
}
