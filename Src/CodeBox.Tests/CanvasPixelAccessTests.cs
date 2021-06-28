using ShapeCreator.Core;
using ShapeCreator.Core.Exceptions;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.ExpectedExceptionHelpers;

namespace ShapeCreator.Tests
{
    public class CanvasPixelAccessTests : CommandTestbase
    {

        public CanvasPixelAccessTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void GetPixel_ValidPixelPointProvidedOn1x1SquareBlankCanvas_ShouldGetBlankChar()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 1;
            Canvas canvas = Factory_Canvas(canvasWidth, canvasHeight);
            var expectedPixel = new PixelChar(DrawingChars.BlankSpaceChar);

            //Act
            var actualPixel = canvas.GetPixel(new CartesianPoint(canvasWidth, canvasHeight));

            //Assert
            Assert.True(expectedPixel.IsEquals(actualPixel));
        }

        [Fact]
        public void GetPixel_ValidPixelPointProvidedOn1x1SquareFilledCanvas_ShouldGetFillChar()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 1;
            Canvas canvas = Factory_Canvas(canvasWidth, canvasHeight);
            var expectedPixel = new PixelChar('o');
            var colorChar = 'o';
            var bucketFillObject = Factory_BucketFillObject(canvasWidth, canvasHeight, colorChar, canvas);
            bucketFillObject.Draw();

            //Act
            var actualPixel = canvas.GetPixel(new CartesianPoint(canvasWidth, canvasHeight));

            //Assert
            Assert.True(expectedPixel.IsEquals(actualPixel));
        }

        [Fact]
        public void GetPixel_PixelPointWithXBiggerThanCanvasBoundaryProvided_ShouldThrowException()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 1;
            Canvas canvas = Factory_Canvas(canvasWidth, canvasHeight);
            var invalidXBiggerThanCanvasBoundary = canvasWidth + 1;

            //Act + Assert
            ExpectExceptionType<XCoordinateExceedsCanvasBoundaryException>(
                () => canvas.GetPixel(new CartesianPoint(invalidXBiggerThanCanvasBoundary, canvasHeight)));
        }

        [Fact]
        public void GetPixel_PixelPointWithYBiggerThanCanvasBoundaryProvided_ShouldThrowException()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 1;
            Canvas canvas = Factory_Canvas(canvasWidth, canvasHeight);
            var invalidYBiggerThanCanvasBoundary = canvasHeight + 1;

            //Act + Assert
            ExpectExceptionType<YCoordinateExceedsCanvasBoundaryException>(
                () => canvas.GetPixel(new CartesianPoint(canvasWidth, invalidYBiggerThanCanvasBoundary)));
        }

        [Fact]
        public void DrawPixel_ValidPixelPointProvidedOn1x1SquareBlankCanvas_ShouldDrawGivenPixelChar()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 1;
            Canvas canvas = Factory_Canvas(canvasWidth, canvasHeight);
            var expectedPixel = new PixelChar('n');

            //Act
            canvas.DrawPixel(expectedPixel, new CartesianPoint(canvasWidth, canvasHeight));

            //Get actual pixel
            var actualPixel = canvas.GetPixel(new CartesianPoint(canvasWidth, canvasHeight));

            //Assert
            Assert.True(expectedPixel.IsEquals(actualPixel));
        }

        [Fact]
        public void DrawPixel_PixelPointWithXBiggerThanCanvasBoundaryProvided_ShouldThrowException()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 1;
            Canvas canvas = Factory_Canvas(canvasWidth, canvasHeight);
            var invalidXBiggerThanCanvasBoundary = canvasWidth + 1;

            //Act + Assert
            ExpectExceptionType<XCoordinateExceedsCanvasBoundaryException>(
                () => canvas.DrawPixel(new PixelChar(),  new CartesianPoint(invalidXBiggerThanCanvasBoundary, canvasHeight)));
        }

        [Fact]
        public void DrawPixel_PixelPointWithYBiggerThanCanvasBoundaryProvided_ShouldThrowException()
        {
            //Arrange
            int canvasWidth = 1, canvasHeight = 1;
            Canvas canvas = Factory_Canvas(canvasWidth, canvasHeight);
            var invalidYBiggerThanCanvasBoundary = canvasHeight + 1;

            //Act + Assert
            ExpectExceptionType<YCoordinateExceedsCanvasBoundaryException>(
                () => canvas.DrawPixel(new PixelChar(), new CartesianPoint(canvasWidth, invalidYBiggerThanCanvasBoundary)));
        }


    }
}
