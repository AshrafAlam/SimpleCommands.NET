using Xunit.Abstractions;

namespace ShapeCreator.Tests.TestHelpers
{
    public class Testbase
    {
        protected readonly ITestOutputHelper Output;

        public Testbase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}
