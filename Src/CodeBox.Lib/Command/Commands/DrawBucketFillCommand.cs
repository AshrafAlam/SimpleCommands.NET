using System;
using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.DrawingObjects;
using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core.Command.Commands
{
    public class DrawBucketFillCommand : DrawObjectCommand
    {

        public DrawBucketFillCommand() : base("B")
        {

        }

        public override void Execute(Canvas canvas, string[] args)
        {
            var expectedBucketFillCommandArgumentLength = 3;

            if (args.Length != expectedBucketFillCommandArgumentLength)
                throw new InvalidCommandArgumentLengthException(expectedBucketFillCommandArgumentLength);

            var bucketFillPoint = new[] {args[0], args[1]}.ParseToCartesianPoint();
            var bucketFillChar = new PixelChar(args[2][0]);
            var bucketFullObject = new BucketFillObject(bucketFillPoint, canvas, bucketFillChar);

            bucketFullObject.Draw();
        }
    }
}