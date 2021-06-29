using SimpleCommands.Core;
using SimpleCommands.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace SimpleCommands.Tests
{
    public class HelloWriterTests : CommandTestbase
    {
        HelloWriter Factory_HelloWriter()
        {
            return new HelloWriter(TestConsoleOutput);
        }

        public HelloWriterTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WriteLine_TestStringWritten_ShouldMatchOutoutAsExpected()
        {
            //Arrange
            var helloWriter = Factory_HelloWriter();
            const string HELLO_PARAM = "Ashraf";
            const string EXPECTED_OUTPUT = "Hello Ashraf\r\n";

            //Act
            helloWriter.WriteLine(HELLO_PARAM);

            //Get output
            var actualOutput = TestConsoleOutput.ToString();

            //Assert
            Assert.Equal(EXPECTED_OUTPUT, actualOutput);
        }

    }
}
