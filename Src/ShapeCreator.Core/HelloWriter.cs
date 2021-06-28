using ShapeCreator.Core.IO;
using System.IO;

namespace ShapeCreator.Core
{
    public class HelloWriter
    {
        StringWriter stringWriter = new StringWriter();

        public HelloWriter(IOutput output)
        {
            _output = output;
        }

        private readonly IOutput _output;

        public void WriteLine(string str)
        {
            var ouputText = "Hello " + str;
            stringWriter.WriteLine(ouputText);
            _output.WriteLine(ouputText);
        }

        public override string ToString()
        {
            return stringWriter.ToString();
        }
    }
}