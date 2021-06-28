using SimpleCommands.Core.IO;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SimpleCommands.TestHelpers
{
    public class TestConsoleOutput : OutputBase
    {
        public TestConsoleOutput(ITestOutputHelper output) : 
            base((lineToWrite) => output.WriteLine(lineToWrite))
        {

        }

        public TestConsoleOutput() : this(new TestOutputHelper())
        {
        }
    }
}
