using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.DrawingObjects;

namespace ShapeCreator.Core.Command.Commands
{
    public class DrawLineCommand : DrawObjectCommand
    {

        public DrawLineCommand() : base("L")
        {

        }

        public override void Execute(Canvas canvas, string[] args)
        {
            var lineObject = new LineObject(args.ParseToCartesianDimension(), canvas);

            lineObject.Draw();
        }
    }
}