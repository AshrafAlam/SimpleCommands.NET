using System;
using System.IO;

namespace ShapeCreator.Core.IO
{
    public abstract class OutputBase : IOutput
    {
        readonly StringWriter _stringWriter = new StringWriter();
        readonly Action<string> _writeAction;
        public OutputBase(Action<string> writeAction)
        {
            _writeAction = writeAction;
        }
        public void WriteLine(string lineToWrite)
        {
            _stringWriter.WriteLine(lineToWrite);
            if (_writeAction != null)
                _writeAction(lineToWrite);
        }
        public override string ToString()
        {
            return _stringWriter.ToString();
        }
    }
}