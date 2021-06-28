
using SimpleCommands.Core.Exceptions;
using SimpleCommands.Core.IO;

namespace SimpleCommands.Core.Command.Commands
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
                throw new InvalidCommandArgumentLengthException(1);

            var helloWriter = new HelloWriter(_output);

            helloWriter.WriteLine(args[0]);
        }
    }
}