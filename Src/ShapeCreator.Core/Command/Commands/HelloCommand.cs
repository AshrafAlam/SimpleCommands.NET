
using ShapeCreator.Core.IO;
using System;

namespace ShapeCreator.Core.Command.Commands
{
    public class HelloCommand : BasicCommand
    {
        public HelloCommand(IOutput output) : base("H") 
        {
            _output = output;
        }

        private readonly IOutput _output;

        public override void Execute(string[] args)
        {
            if (args.Length == 0)
                throw new IndexOutOfRangeException("No parameter supplied for hello command.");

            var helloWriter = new HelloWriter(args[0], _output);

            helloWriter.WriteLine();
        }
    }
}