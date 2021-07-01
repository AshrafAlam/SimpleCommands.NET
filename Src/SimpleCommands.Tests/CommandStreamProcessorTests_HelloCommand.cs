using SimpleCommands.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace SimpleCommands.Tests
{
    public class CommandStreamProcessorTests_HelloCommand : CommandTestbase
    {
        public CommandStreamProcessorTests_HelloCommand(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void ProcessCommands_HelloCommandPassed_ShouldRespondHello()
        {
            //Arrange 
            var commandStreamProcessor =
                Factory_CommandStreamProcessor("ProcessCommands_Hello_SingleCommand_Input.txt");
            var expectedOutput = TestDataReader.LoadAsString("ProcessCommands_Hello_SingleCommand_Output.txt");

            //Act
            commandStreamProcessor.ProcessCommands();

            //Get output
            var actualOutput = commandStreamProcessor.GetOutput().ToString();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ProcessCommands_MultipleHelloCommandsPassed_ShouldRespondMultipleLines()
        {
            //Arrange 
            var commandStreamProcessor =
                Factory_CommandStreamProcessor("ProcessCommands_Hello_MultipleCommand_Input.txt");
            var expectedOutput = TestDataReader.LoadAsString("ProcessCommands_Hello_MultipleCommand_Output.txt");

            //Act
            commandStreamProcessor.ProcessCommands();

            //Get output
            var actualOutput = commandStreamProcessor.GetOutput().ToString();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ProcessCommands_HelloCommandsPassedWithNoParam_ShouldDisplayError()
        {
            //Arrange 
            var commandStreamProcessor =
                Factory_CommandStreamProcessor("ProcessCommands_Hello_NoParam_Input.txt");
            var expectedOutput = TestDataReader.LoadAsString("ProcessCommands_Hello_NoParam_Output.txt");

            //Act
            commandStreamProcessor.ProcessCommands();

            //Get output
            var actualOutput = commandStreamProcessor.GetOutput().ToString();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}