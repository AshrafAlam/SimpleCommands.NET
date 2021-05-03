using ShapeCreator.Core;
using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.DrawingObjects;
using Xunit.Abstractions;

namespace ShapeCreator.Tests.TestHelpers
{
    public class CommandTestbase:Testbase
    {
        public CommandTestbase(ITestOutputHelper output):base(output)
        {
        }

        protected TestConsoleOutput _testConsoleOutput;

        private new TestConsoleOutput TestConsoleOutput => _testConsoleOutput ?? (_testConsoleOutput = new TestConsoleOutput(Output));

        protected Canvas Factory_Canvas(int xCordinate, int yCordinate)
        {
            Canvas canvas = new Canvas(new CartesianPoint(xCordinate, yCordinate), TestConsoleOutput);

            return canvas;
        }

        protected static LineObject Factory_LineObject(int upperLeftXForLine, int upperLeftYForLine, int lowerLeftXForLine, int lowerRightYForLine, Canvas canvas)
        {
            CartesianPoint uppderLeftPoint = new CartesianPoint(upperLeftXForLine, upperLeftYForLine);
            CartesianPoint lowerRightPoint = new CartesianPoint(lowerLeftXForLine, lowerRightYForLine);
            LineObject lineObject = new LineObject(new CartesianDimension(uppderLeftPoint, lowerRightPoint), canvas);

            return lineObject;
        }

        protected static RectangleObject Factory_RectangleObject(int upperLeftXForRectangle, int upperLeftYForRectangle, int lowerLeftXForRectangle, int lowerRightYForRectangle, Canvas canvas)
        {
            CartesianPoint uppderLeftPoint = new CartesianPoint(upperLeftXForRectangle, upperLeftYForRectangle);
            CartesianPoint lowerRightPoint = new CartesianPoint(lowerLeftXForRectangle, lowerRightYForRectangle);
            RectangleObject rectangleObject = new RectangleObject(new CartesianDimension(uppderLeftPoint, lowerRightPoint), canvas);

            return rectangleObject;
        }

        protected static BucketFillObject Factory_BucketFillObject(int xPointForBucketFill, int yPointForBucketFill, char color, Canvas canvas)
        {
            CartesianPoint bucketFillPoint = new CartesianPoint(xPointForBucketFill, yPointForBucketFill);
            PixelChar bucketFillColor = new PixelChar(color);
            BucketFillObject bucketFillObject = new BucketFillObject(bucketFillPoint, canvas, bucketFillColor);

            return bucketFillObject;
        }

        protected CommandStreamProcessor Factory_CommandStreamProcessor(string inputFilePath)
        {
            var fileStreamInput = new FileStreamInput(inputFilePath);
            var canvasCommandStreamProcessor =
                new CommandStreamProcessor(fileStreamInput, TestConsoleOutput);

            return canvasCommandStreamProcessor;
        }

        protected CommandHandler Factory_CommandHandler()
        {
            return new CommandHandler(new DummayOutput());
        }

        protected CommandHandler Factory_CommandHandlerWithCanvas()
        {
            var commandHandler = new CommandHandler(new DummayOutput());
            var createCanvasCommandName = "C";
            var createCanvasCommandArgs = new[] { "1", "1"};
            var createCanvasCommandValues = Factory_CommandValues(createCanvasCommandName, createCanvasCommandArgs);
            commandHandler.ExecuteCommand(createCanvasCommandValues);

            return commandHandler;
        }

        protected CommandValues Factory_CommandValues(string commandName, params string[] commandArgs)
        {
            return new CommandValues {CommandName = commandName, CommandArgs = commandArgs};
        }
    }
}
