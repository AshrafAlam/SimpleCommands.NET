using System;
using System.Linq;
using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core.Command.Infrastructure
{
    public static class CommandArgParser
    {
        public static CommandValues ParseToCommandValues(string commandLine)
        {
            var parts = commandLine.Split(' ').ToList();
            string commandName = parts[0];
            parts.RemoveAt(0);

            string[] commandArgs = parts.ToArray<string>();

            return new CommandValues
            {
                CommandName = commandName,
                CommandArgs = commandArgs
            };
        }

        public static int[] ParseToIntArray(this string[] args, int? start = null, int? end = null)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (start == null)
                start = 0;

            if (start < 0)
                throw new ArgumentOutOfRangeException(nameof(start));

            if (end == null)
                end = args.Length - 1;

            if (end >= args.Length)
                throw new ArgumentOutOfRangeException(nameof(end));

            int[] intArray = new int[(int) (end - start) + 1];

            int intArrayCounter = 0;

            for (var i = (int) start; i <= end; i++)
            {
                if (!int.TryParse(args[i], out var intValue))
                    ExceptionThrower.Throws<InvalidCommandArgumentFormatException>();

                intArray[intArrayCounter++] = intValue;
            }

            return intArray;
        }

        public static CartesianPoint ParseToCartesianPoint(this string[] args)
        {
            if (args.Length != ExpectedCommandArgumentLengthForCartesianPoint)
               throw new InvalidCommandArgumentLengthException(ExpectedCommandArgumentLengthForCartesianPoint);

            var start = 0;

            var argsInt = args.ParseToIntArray(start, start + 1);

            var xCordinate = argsInt[0];
            var yCondinate = argsInt[1];

            return new CartesianPoint(xCordinate, yCondinate);

        }
        
        public static CartesianDimension ParseToCartesianDimension(this string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (args.Length != ExpectedCommandArgumentLengthForCartesianDimension)
                throw new InvalidCommandArgumentLengthException(ExpectedCommandArgumentLengthForCartesianDimension);

            var upperLeftCordinate = new[] {args[0], args[1]}.ParseToCartesianPoint();
            var lowerRightCordinate = new[] {args[2], args[3]}.ParseToCartesianPoint();

            return new CartesianDimension
            (
                upperLeftCordinate,
                lowerRightCordinate
            );

        }

        const int ExpectedCommandArgumentLengthForCartesianDimension = 4;
        const int ExpectedCommandArgumentLengthForCartesianPoint = 2;

    }
}