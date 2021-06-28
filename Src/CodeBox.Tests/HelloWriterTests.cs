using CodeBox.Core;
using CodeBox.Tests.TestHelpers;
using Xunit;
using Xunit.Abstractions;

namespace CodeBox.Tests
{
    public class HelloWriterTests : CommandTestbase
    {
        HelloWriter Factory_HelloWriter()
        {
            return new HelloWriter(TestConsoleOutput);
        }

        public HelloWriterTests(ITestOutputHelper output):base(output)
        {
        }

        [Fact]
        public void Write_TestStringWritten_ShouldMatchOutoutAsExpected()
        {
            //Arrange
            var helloWriter = Factory_HelloWriter();
            const string HELLO_PARAM = "Ashraf";
            const string EXPECTED_OUTPUT = "Hello Ashraf\r\n";
           
            //Act
            helloWriter.WriteLine(HELLO_PARAM);

            //Assert
            Assert.Equal(EXPECTED_OUTPUT, TestConsoleOutput.ToString());
        }
               
    }
}
