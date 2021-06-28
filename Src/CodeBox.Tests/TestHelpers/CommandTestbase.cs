using CodeBox.Core.Command.Infrastructure;
using Xunit.Abstractions;

namespace CodeBox.Tests.TestHelpers
{
    public class CommandTestbase:Testbase
    {
        public CommandTestbase(ITestOutputHelper output):base(output)
        {
        }

        protected TestConsoleOutput _testConsoleOutput;

        private new TestConsoleOutput TestConsoleOutput => _testConsoleOutput ?? (_testConsoleOutput = new TestConsoleOutput(Output));

        protected CommandStreamProcessor Factory_CommandStreamProcessor(string inputFilePath)
        {
            var fileStreamInput = new FileStreamInput(inputFilePath);
            var commandStreamProcessor =
                new CommandStreamProcessor(fileStreamInput, TestConsoleOutput);

            return commandStreamProcessor;
        }

        protected CommandHandler Factory_CommandHandler()
        {
            return new CommandHandler(new DummayOutput());
        }

        protected CommandValues Factory_CommandValues(string commandName, params string[] commandArgs)
        {
            return new CommandValues {CommandName = commandName, CommandArgs = commandArgs};
        }
    }
}
