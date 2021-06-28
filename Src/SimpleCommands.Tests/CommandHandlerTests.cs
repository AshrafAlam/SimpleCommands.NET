using SimpleCommands.Core.Command.Infrastructure;
using SimpleCommands.Core.Exceptions;
using SimpleCommands.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace SimpleCommands.Tests
{
    public class CommandHandlerTests : CommandTestbase
    {
        public CommandHandlerTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void ExecuteCommand_InvalidCommandProvided_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                new CommandHandler(new DummayOutput());
            var invalidCommand = "x";
            var commandValuesWithInvalidCommand = Factory_CommandValues(invalidCommand);

            //Act + Assert
            ExpectedExceptionHelpers.ExpectExceptionType<InvalidCommandException>(() =>
                commandHandler.ExecuteCommand(commandValuesWithInvalidCommand));
        }
              
    }
}