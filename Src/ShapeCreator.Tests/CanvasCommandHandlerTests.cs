using ShapeCreator.Core.Exceptions;
using ShapeCreator.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;
using static ShapeCreator.Tests.TestHelpers.ExpectedExceptionHelpers;

namespace ShapeCreator.Tests
{
    public class CanvasCommandHandlerTests : CanvasTestbase
    {
        public CanvasCommandHandlerTests(ITestOutputHelper output) : base(output)
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

        [Fact]
        public void ExecuteCommand_DrawingObjectAttemptedBeforeCreatingCanvas_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                Factory_CommandHandler();
            var commandName = "L";
            var invalidFormatCommandArgs = new[] {"1", "1", "2", "3"};
            var commandValuesWithInvalidFormatArguments = Factory_CommandValues(commandName, invalidFormatCommandArgs);

            //Act + Assert
            ExpectExceptionType<CanvasMustBeCreatedFirstException>(() =>
                commandHandler.ExecuteCommand(commandValuesWithInvalidFormatArguments));
        }

        [Fact]
        public void ExecuteCommand_InvalidFormatCommandArgumentsProvidesForDrawingLineCommand_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                Factory_CommandHandlerWithCanvas();

            //Create a canvas
            
            var drawLineCommandName = "L";
            var drawLineInvalidFormatCommandArgs = new[] { "x", "x", "x", "x" };
            var drawLineCommandValuesWithInvalidFormatArguments = Factory_CommandValues(drawLineCommandName, drawLineInvalidFormatCommandArgs);

            //Act + Assert
            ExpectExceptionType<InvalidCommandArgumentFormatException>(() =>
                commandHandler.ExecuteCommand(drawLineCommandValuesWithInvalidFormatArguments));
        }

        [Fact]
        public void ExecuteCommand_InvalidLengthCommandArgumentsProvidesForDrawingLineCommand_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                Factory_CommandHandlerWithCanvas();

            var drawLineCommandName = "L";
            var drawLineInvalidLengthCommandArgs = new[] { "1", "1" };
            var drawLineCommandValuesWithInvalidLengthArguments = Factory_CommandValues(drawLineCommandName, drawLineInvalidLengthCommandArgs);

            //Act + Assert
            ExpectExceptionType<InvalidCommandArgumentLengthException>(() =>
                commandHandler.ExecuteCommand(drawLineCommandValuesWithInvalidLengthArguments));
        }

        [Fact]
        public void ExecuteCommand_InvalidFormatCommandArgumentsProvidesForDrawingRectangleCommand_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                Factory_CommandHandlerWithCanvas();
            var drawRectangleCommandName = "R";
            var drawRectangleInvalidFormatCommandArgs = new[] { "x", "x", "x", "x" };
            var drawLineCommandValuesWithInvalidFormatArguments = Factory_CommandValues(drawRectangleCommandName, drawRectangleInvalidFormatCommandArgs);

            //Act + Assert
            ExpectExceptionType<InvalidCommandArgumentFormatException>(() =>
                commandHandler.ExecuteCommand(drawLineCommandValuesWithInvalidFormatArguments));
        }

        [Fact]
        public void ExecuteCommand_InvalidLengthCommandArgumentsProvidesForDrawingRectangleCommand_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                Factory_CommandHandlerWithCanvas();

            var drawRectangleCommandName = "R";
            var drawRectangleInvalidLengthCommandArgs = new[] { "1", "1" };
            var drawRectangleCommandValuesWithInvalidLengthArguments = Factory_CommandValues(drawRectangleCommandName, drawRectangleInvalidLengthCommandArgs);

            //Act + Assert
            ExpectExceptionType<InvalidCommandArgumentLengthException>(() =>
                commandHandler.ExecuteCommand(drawRectangleCommandValuesWithInvalidLengthArguments));
        }

        [Fact]
        public void ExecuteCommand_InvalidFormatCommandArgumentsProvidesForDrawingBucketFillCommand_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                Factory_CommandHandlerWithCanvas();
            var drawBucketFillCommandName = "B";
            var drawBucketFillInvalidFormatCommandArgs = new[] { "x", "x", "x" };
            var drawBucketFillCommandValuesWithInvalidFormatArguments = Factory_CommandValues(drawBucketFillCommandName, drawBucketFillInvalidFormatCommandArgs);

            //Act + Assert
            ExpectExceptionType<InvalidCommandArgumentFormatException>(() =>
                commandHandler.ExecuteCommand(drawBucketFillCommandValuesWithInvalidFormatArguments));
        }

        [Fact]
        public void ExecuteCommand_InvalidLengthCommandArgumentsProvidesForDrawingBucketFillCommand_ShouldThrowException()
        {
            //Arrange 
            var commandHandler =
                Factory_CommandHandlerWithCanvas();

            var drawBucketFillCommandName = "B";
            var drawBucketFillInvalidFormatCommandArgs = new[] { "1", "1",};
            var drawBucketFillCommandValuesWithInvalidFormatArguments = Factory_CommandValues(drawBucketFillCommandName, drawBucketFillInvalidFormatCommandArgs);

            //Act + Assert
            ExpectExceptionType<InvalidCommandArgumentLengthException>(() =>
                commandHandler.ExecuteCommand(drawBucketFillCommandValuesWithInvalidFormatArguments));
        }
    }
}