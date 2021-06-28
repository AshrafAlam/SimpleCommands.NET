using SimpleCommands.Core.Command.Infrastructure;

namespace SimpleCommands.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleOutput = new ConsoleOutput();
            var consoleInput = new ConsoleInput();
            var commandHandler = new CommandHandler(consoleOutput);

            var canvasCommandStreamProcessor =
                new CommandStreamProcessor(consoleInput, consoleOutput, commandHandler);

            canvasCommandStreamProcessor.ProcessCommands();
        }
    }
}
