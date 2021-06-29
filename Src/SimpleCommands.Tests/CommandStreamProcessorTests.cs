using SimpleCommands.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace SimpleCommands.Tests
{
    public class CommandStreamProcessorTests: CommandTestbase
    {
        public CommandStreamProcessorTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void ProcessCommands_NoCommandPassed_ShouldProvideEmptyResponse()
        {
            //Arrange 
            var commandStreamProcessor =
                Factory_CommandStreamProcessor("ProcessCommands_NoCommand_Input.txt");
            var expectedOutput = CommandTestHelpers.ReadFromFile("ProcessCommands_NoCommand_Output.txt");

            //Act
            commandStreamProcessor.ProcessCommands();

            //Get output
            var actualOutput = commandStreamProcessor.GetOutput().ToString();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ProcessCommands_WrongCommandsPassed_Should()
        {
            //Arrange 
            var commandStreamProcessor =
                Factory_CommandStreamProcessor("ProcessCommands_WrongCommand_Input.txt");
            var expectedOutput = CommandTestHelpers.ReadFromFile("ProcessCommands_WrongCommand_Output.txt");

            //Act
            commandStreamProcessor.ProcessCommands();

            //Get output
            var actualOutput = commandStreamProcessor.GetOutput().ToString();

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

    }
}