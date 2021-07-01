using SimpleCommands.Core.Exceptions;
using SimpleCommands.Core.IO;

namespace SimpleCommands.Core.Command.Infrastructure
{
    public class CommandStreamProcessor
    {
        private readonly IOutput _output;
        private readonly IInput _input;
        private readonly ICommandHandler _commandHandler;

        public CommandStreamProcessor(IInput input, IOutput output, ICommandHandler commandHandler)
        {
            _input = input;
            _output = output;
            _commandHandler = commandHandler;
        }

        public void ProcessCommands()
        {
            while (true)
            {
                _output.WriteLine("Enter command: ");

                var commandLine = _input.ReadLine();

                if (string.IsNullOrEmpty(commandLine)) break;

                _output.WriteLine("User entered command: " + commandLine);

                try
                {
                    var commandValues = CommandArgParser.ParseToCommandValues(commandLine.Trim());
                    _commandHandler.ExecuteCommand(commandValues);
                }
                catch (CommandException coreException)
                {
                    _output.WriteLine($"Error: {coreException.Message}.");
                }
            }

        }

    }
}
