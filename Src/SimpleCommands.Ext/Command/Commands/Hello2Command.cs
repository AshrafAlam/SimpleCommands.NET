
using CodeBox.Core.Exceptions;
using CodeBox.Core.IO;

namespace CodeBox.Core.Command.Commands
{
    public class Hello2Command : BasicCommand
    {
        public Hello2Command(IOutput output) : base("H2") 
        {
            _output = output;
        }

        private readonly IOutput _output;

        public override void Execute(string[] args)
        {
            if (args.Length == 0)
                throw new InvalidCommandArgumentLengthException(1);

            var helloWriter = new Hello2Writer(_output);

            helloWriter.WriteLine(args[0]);
        }
    }
}