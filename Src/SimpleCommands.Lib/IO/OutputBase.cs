using System;

namespace SimpleCommands.Core.IO
{
    public abstract class OutputBase : IOutput
    {
        readonly Action<string> _writeAction;
        public OutputBase(Action<string> writeAction)
        {
            _writeAction = writeAction;
        }
        public virtual void WriteLine(string lineToWrite)
        {
            if (_writeAction != null)
                _writeAction(lineToWrite);
        }
    }
}