using CodeBox.Core.IO;

namespace CodeBox.Core
{
    public class HelloWriter
    {
        public HelloWriter(IOutput output)
        {
            _output = output;
        }

        private readonly IOutput _output;

        public void WriteLine(string str)
        {
            _output.WriteLine("Hello " + str);
        }

    }
}