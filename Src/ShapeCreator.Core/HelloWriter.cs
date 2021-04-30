using ShapeCreator.Core.IO;

namespace ShapeCreator.Core
{
    public class HelloWriter
    {
        public HelloWriter(string text, IOutput output)
        {
            _text = text;
            _output = output;
        }

        private readonly IOutput _output;
        private readonly string _text;

        public void WriteLine()
        {
            _output.WriteLine("Hello " + _text);
        }
    }
}