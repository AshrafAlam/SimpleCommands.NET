using ShapeCreator.Core.IO;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ShapeCreator.Tests.TestHelpers
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
