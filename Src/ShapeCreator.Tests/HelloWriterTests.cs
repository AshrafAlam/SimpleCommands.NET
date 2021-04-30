using ShapeCreator.Core;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace ShapeCreator.Tests
{
    public class HelloWriterTests : Testbase
    {
        HelloWriter Factory_HelloWriter()
        {
            return new HelloWriter(new TestConsoleOutput(Output));
        }

        public HelloWriterTests(ITestOutputHelper output):base(output)
        {
           
        }

        [Fact]
        public void Write_Create1x1SquareCanvas_ShouldCreateBlankCanvas()
        {
            //Arrange
            const string HELLO_PARAM = "Ashraf";
            var helloWriter = Factory_HelloWriter();

            //Act
            helloWriter.WriteLine(HELLO_PARAM);

            //Assert
            //Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }
    }
}
