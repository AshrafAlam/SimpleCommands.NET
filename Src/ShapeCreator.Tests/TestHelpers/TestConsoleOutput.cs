using ShapeCreator.Core;
using ShapeCreator.Core.IO;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ShapeCreator.Tests.TestHelpers
{
    public class TestConsoleOutput : OutputBase
    {
        private readonly ITestOutputHelper _output;

        public TestConsoleOutput() : this(new TestOutputHelper())
        {
        }

        public TestConsoleOutput(ITestOutputHelper output)
        {
            _output = output;
        }

        public override void WriteLine(char[] lineToWrite)
        {
            _output.WriteLine(new string(lineToWrite));
        }
    }
}
