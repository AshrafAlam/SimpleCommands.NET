using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;

namespace ShapeCreator.Tests
{
    public class CanvasCommandStreamProcessorTests : CanvasTestbase
    {
        public CanvasCommandStreamProcessorTests(ITestOutputHelper output):base(output)
        {
           
        }

        [Fact]
        public void ProcessCanvasCommands_CommandsWith20X4Canvas2Lines1Rectangle1BucketFillProvided_ShouldBuildExpectedCanvas()
        {
            //Arrange 
            var canvasCommandStreamProcessor =
                Factory_CanvasCommandStreamProcessor(CommandWith20X4Canvas2Lines1Rectangle1BucketFillInputFilePath);
            var expectedCanvas =
                BuildCanvasFromFile(CommandWith20X4Canvas2Lines1Rectangle1BucketFillOutputCanvasFilePath);

            //Act
            canvasCommandStreamProcessor.ProcessCanvasCommands();

            //Get Canvas
            var actualCanvas = canvasCommandStreamProcessor.GetCanvas();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void ProcessCanvasCommands_CommandsWith20X4Canvas1LineProvided_ShouldBuildExpectedCanvas()
        {
            //Arrange 
            var canvasCommandStreamProcessor =
                Factory_CanvasCommandStreamProcessor(CommandWith20X4Canvas1LineInputFilePath);
            var expectedCanvas =
                BuildCanvasFromFile(CommandWith20X4Canvas1LineOutputCanvasFilePath);

            //Act
            canvasCommandStreamProcessor.ProcessCanvasCommands();

            //Get Canvas
            var actualCanvas = canvasCommandStreamProcessor.GetCanvas();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void ProcessCanvasCommands_CommandsWith20X4CanvasProvided_ShouldBuildExpectedCanvas()
        {
            //Arrange 
            var canvasCommandStreamProcessor =
                Factory_CanvasCommandStreamProcessor(CommandWith20X4CanvasInputFilePath);
            var expectedCanvas =
                BuildCanvasFromFile(CommandWith20X4CanvasOutputCanvasFilePath);
            
            //Act
            canvasCommandStreamProcessor.ProcessCanvasCommands();

            //Get Canvas
            var actualCanvas = canvasCommandStreamProcessor.GetCanvas();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }
    }
}