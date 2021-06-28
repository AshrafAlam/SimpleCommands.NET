using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.CanvasTestHelpers;
using static ShapeCreator.Tests.TestHelpers.TestDataPaths;

namespace ShapeCreator.Tests
{
    public class CommandStreamProcessorTests : CommandTestbase
    {
        public CommandStreamProcessorTests(ITestOutputHelper output):base(output)
        {
           
        }

        [Fact]
        public void ProcessCanvasCommands_CommandsWith20X4Canvas2Lines1Rectangle1BucketFillProvided_ShouldBuildExpectedCanvas()
        {
            //Arrange 
            var canvasCommandStreamProcessor =
                Factory_CommandStreamProcessor(CommandWith20X4Canvas2Lines1Rectangle1BucketFillInputFilePath);
            var expectedCanvas =
                BuildCanvasFromFile(CommandWith20X4Canvas2Lines1Rectangle1BucketFillOutputCanvasFilePath);

            //Act
            canvasCommandStreamProcessor.ProcessCommands();

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
                Factory_CommandStreamProcessor(CommandWith20X4Canvas1LineInputFilePath);
            var expectedCanvas =
                BuildCanvasFromFile(CommandWith20X4Canvas1LineOutputCanvasFilePath);

            //Act
            canvasCommandStreamProcessor.ProcessCommands();

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
                Factory_CommandStreamProcessor(CommandWith20X4CanvasInputFilePath);
            var expectedCanvas =
                BuildCanvasFromFile(CommandWith20X4CanvasOutputCanvasFilePath);
            
            //Act
            canvasCommandStreamProcessor.ProcessCommands();

            //Get Canvas
            var actualCanvas = canvasCommandStreamProcessor.GetCanvas();

            //Assert
            Assert.True(expectedCanvas.IsEquals(actualCanvas));
        }

        [Fact]
        public void ProcessCommands_HelloCommandPassed_ShouldRespondHello()
        {
            //Arrange 
            var commandStreamProcessor =
                Factory_CommandStreamProcessor("CommandWithHelloWorld_Input_Ashraf.txt");
            var expectedOutput = "enter command:\r\nHello Ashraf\r\nenter command:\r\n";

            //Act
            commandStreamProcessor.ProcessCommands();

            //Get Canvas
            var output = commandStreamProcessor.GetOutput();

            //Assert
            Assert.Equal(expectedOutput, output.ToString());
        }
    }
}