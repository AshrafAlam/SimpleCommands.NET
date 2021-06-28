using CodeBox.Core.Exceptions;
using CodeBox.Core.IO;

namespace CodeBox.Core.Command.Infrastructure
{
    public class CommandStreamProcessor
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public CommandStreamProcessor(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        private CommandHandler _commandHandler;

        private CommandHandler CommandHandler =>
            _commandHandler ?? (_commandHandler = new CommandHandler(_output));

        public void ProcessCommands()
        {
            while (true)
            {
                _output.WriteLine("enter command: ");

                var commandLine = _input.ReadLine();

                if (string.IsNullOrEmpty(commandLine)) break;

                _output.WriteLine("user entered command: " + commandLine);

                try
                {
                    var commandValues = CommandArgParser.ParseToCommandValues(commandLine.Trim());
                    CommandHandler.ExecuteCommand(commandValues);
                }
                catch (CommandException coreException)
                {
                    _output.WriteLine($"Error: {coreException.Message}.");
                }
            }

        }

    }
}
