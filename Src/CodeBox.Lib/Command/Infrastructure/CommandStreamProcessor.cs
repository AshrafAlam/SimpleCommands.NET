using ShapeCreator.Core.Exceptions;
using ShapeCreator.Core.IO;

namespace ShapeCreator.Core.Command.Infrastructure
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

        private CommandHandler _canvasCommandHandler;

        private CommandHandler CanvasCommandHandler =>
            _canvasCommandHandler ?? (_canvasCommandHandler = new CommandHandler(_output));

        public void ProcessCanvasCommands()
        {
            while (true)
            {
                _output.WriteLineWithTrack("enter command:");

                var commandLine = _input.ReadLine();

                if (string.IsNullOrEmpty(commandLine)) break;

                try
                {
                    var commandValues = CommandArgParser.ParseToCommandValues(commandLine.Trim());
                    CanvasCommandHandler.ExecuteCommand(commandValues);
                }
                catch (DrawingException coreException)
                {
                    _output.WriteLineWithTrack($"Error: {coreException.Message}.");
                }
            }

        }

    }
}
