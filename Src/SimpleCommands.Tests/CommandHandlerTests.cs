using CodeBox.Core.Command.Infrastructure;
using CodeBox.Core.Exceptions;
using CodeBox.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static CodeBox.Tests.TestHelpers.ExpectedExceptionHelpers;

namespace CodeBox.Tests
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
            ExpectExceptionType<InvalidCommandException>(() =>
                commandHandler.ExecuteCommand(commandValuesWithInvalidCommand));
        }
              
    }
}