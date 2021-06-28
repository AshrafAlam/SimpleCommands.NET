using CodeBox.Core.IO;

namespace CodeBox.Core
{
    public class Hello2Writer
    {
        public Hello2Writer(IOutput output)
        {
            _output = output;
        }

        private readonly IOutput _output;

        public void WriteLine(string str)
        {
            _output.WriteLine("Hello 2: " + str);
        }

    }
}