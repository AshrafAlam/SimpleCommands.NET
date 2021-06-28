using Xunit.Abstractions;

namespace ShapeCreator.Tests.TestHelpers
{
    public class Testbase
    {
        protected readonly ITestOutputHelper Output;
        protected readonly TestConsoleOutput TestConsoleOutput;

        public Testbase(ITestOutputHelper output)
        {
            TestConsoleOutput = new TestConsoleOutput(output);
            Output = output;
        }
    }
}
