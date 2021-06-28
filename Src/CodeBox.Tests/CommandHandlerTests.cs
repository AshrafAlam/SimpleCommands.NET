using ShapeCreator.Core.Exceptions;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.ExpectedExceptionHelpers;

namespace ShapeCreator.Tests
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
                Factory_CommandHandler();
            var invalidCommand = "x";
            var commandValuesWithInvalidCommand = Factory_CommandValues(invalidCommand);

            //Act + Assert
            ExpectExceptionType<InvalidCommandException>(() =>
                commandHandler.ExecuteCommand(commandValuesWithInvalidCommand));
        }
              
    }
}