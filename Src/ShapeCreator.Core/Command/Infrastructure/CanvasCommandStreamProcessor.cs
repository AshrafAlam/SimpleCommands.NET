using ShapeCreator.Core.Exceptions;
using ShapeCreator.Core.IO;

namespace ShapeCreator.Core.Command.Infrastructure
{
    public class CanvasCommandStreamProcessor
    {
        private readonly IOutput _output;
        private readonly IInput _input;

        public CanvasCommandStreamProcessor(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }

        private CanvasCommandHandler _canvasCommandHandler;

        private CanvasCommandHandler CanvasCommandHandler =>
            _canvasCommandHandler ?? (_canvasCommandHandler = new CanvasCommandHandler(_output));

        public void ProcessCanvasCommands()
        {
            while (true)
            {
                _output.WriteLine("enter command:");

                var commandLine = _input.ReadLine();

                if (string.IsNullOrEmpty(commandLine)) break;

                try
                {
                    var commandValues = CommandArgParser.ParseToCommandValues(commandLine.Trim());
                    CanvasCommandHandler.ExecuteCommand(commandValues);
                }
                catch (DrawingException coreException)
                {
                    _output.WriteLine($"Error: {coreException.Message}.");
                }
            }

        }

    }
}
