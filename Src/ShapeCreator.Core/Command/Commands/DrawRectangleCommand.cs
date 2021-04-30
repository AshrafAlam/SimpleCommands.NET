using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.DrawingObjects;

namespace ShapeCreator.Core.Command.Commands
{
    public class DrawRectangleCommand : DrawObjectCommand
    {

        public DrawRectangleCommand() : base("R")
        {

        }

        public override void Execute(Canvas canvas, string[] args)
        {
            var rectangleObject = new RectangleObject(args.ParseToCartesianDimension(), canvas);

            rectangleObject.Draw();
        }
    }
}