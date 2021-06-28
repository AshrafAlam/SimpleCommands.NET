using SimpleCommands.Core.IO;

namespace SimpleCommands.Core
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