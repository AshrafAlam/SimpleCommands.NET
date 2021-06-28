using ShapeCreator.Core;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;
using static Xunit.Assert;

namespace ShapeCreator.Tests
{
    public class CanvasTestHelperTests:Testbase
    {
        public CanvasTestHelperTests(ITestOutputHelper output):base(output)
        {

        }

        [Fact]
        public void IsEqual_TwoSeperateCanvasInstancesAreGiven_ShouldReturnTrue()
        {
            //Arrange
            Canvas firstCanvas = BuildCanvasFromFile(BlankCanvas20X4FilePath);
            Canvas secondCanvas = BuildCanvasFromFile(BlankCanvas20X4FilePath);

            //Act
            var isBothCanvasEqual = firstCanvas.IsEquals(secondCanvas);

            //Assert
            True(!firstCanvas.Equals(secondCanvas));
            True(isBothCanvasEqual);

        }
    }
}
