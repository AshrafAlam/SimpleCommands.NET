using SimpleCommands.Core.IO;
using System.IO;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SimpleCommands.TestHelpers
{
    public class TestConsoleOutput : OutputBase
    {
        StringWriter _stringWriter = new StringWriter();
        public TestConsoleOutput(ITestOutputHelper output):
            base((lineToWrite) => output.WriteLine(lineToWrite))
        {
            
        }

        public TestConsoleOutput() : this(new TestOutputHelper())
        {
        }

        public override void WriteLine(string lineToWrite)
        {
            _stringWriter.WriteLine(lineToWrite);
            base.WriteLine(lineToWrite);
        }
        public override string ToString()
        {
            return _stringWriter.ToString();
        }
    }
}
