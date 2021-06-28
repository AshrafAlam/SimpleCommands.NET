using SimpleCommands.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace SimpleCommands.Tests
{
    public class CommandStreamProcessorTests : CommandTestbase
    {
        public CommandStreamProcessorTests(ITestOutputHelper output):base(output)
        {
           
        }

        [Fact]
        public void ProcessCommands_HelloCommandPassed_ShouldRespondHello()
        {
            //Arrange 
            var commandStreamProcessor =
                Factory_CommandStreamProcessor("CommandWithHelloWriter_Input_Ashraf.txt");
            var expectedOutput = CommandTestHelpers.ReadFromFile("CommandWithHelloWriter_Output_Ashraf.txt");

            //Act
            commandStreamProcessor.ProcessCommands();

            //Get Canvas
            var output = commandStreamProcessor.GetOutput();

            //Assert
            Assert.Equal(expectedOutput, output.ToString());
        }
    }
}