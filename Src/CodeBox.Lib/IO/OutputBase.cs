using System.IO;

namespace ShapeCreator.Core.IO
{
    public abstract class OutputBase : IOutput
    {
        StringWriter _stringWriter = new StringWriter();

        public abstract void WriteLine(char[] lineToWrite);
        
        public void WriteLineWithTrack(string lineToWrite)
        {
            _stringWriter.WriteLine(lineToWrite);
            WriteLine(lineToWrite.ToCharArray());
        }
        public override string ToString()
        {
            return _stringWriter.ToString();
        }
    }
}