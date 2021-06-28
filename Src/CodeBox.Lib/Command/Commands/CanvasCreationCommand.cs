using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.IO;

namespace ShapeCreator.Core.Command.Commands
{
    public class CanvasCreationCommand : CommandCore
    {
        private readonly IOutput _output;

        public CanvasCreationCommand(IOutput output) : base("C")
        {
            _output = output;
        }

        public Canvas CreateCommand(string[] args)
        {
            var canvasBoundary = args.ParseToCartesianPoint();

            return new Canvas(canvasBoundary, _output);
        }
    }
}