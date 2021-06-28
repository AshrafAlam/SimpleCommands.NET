using System;
using System.Linq;
using CodeBox.Core.Exceptions;

namespace CodeBox.Core.Command.Infrastructure
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
    }
}