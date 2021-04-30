using ShapeCreator.Core;
using ShapeCreator.Core.Command;
using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.DrawingObjects;
using Xunit.Abstractions;

namespace ShapeCreator.Tests.TestHelpers
{
    public class CanvasTestbase:Testbase
    {
        public CanvasTestbase(ITestOutputHelper output):base(output)
        {
        }

        private TestConsoleOutput _testConsoleOutput;

        private TestConsoleOutput TestConsoleOutput => _testConsoleOutput ?? (_testConsoleOutput = new TestConsoleOutput(Output));

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

        protected CanvasCommandStreamProcessor Factory_CanvasCommandStreamProcessor(string inputFilePath)
        {
            var fileStreamInput = new FileStreamInput(inputFilePath);
            var canvasCommandStreamProcessor =
                new CanvasCommandStreamProcessor(fileStreamInput, TestConsoleOutput);

            return canvasCommandStreamProcessor;
        }

        protected CanvasCommandHandler Factory_CommandHandler()
        {
            return new CanvasCommandHandler(new DummayOutput());
        }

        protected CanvasCommandHandler Factory_CommandHandlerWithCanvas()
        {
            var commandHandler = new CanvasCommandHandler(new DummayOutput());
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
