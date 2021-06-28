using CodeBox.Core.IO;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CodeBox.Tests.TestHelpers
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
