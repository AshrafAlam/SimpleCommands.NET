using System;
using System.IO;
using SimpleCommands.Core;
using SimpleCommands.Core.IO;

namespace SimpleCommands.TestHelpers
{
    public class FileStreamInput : IInput, IDisposable
    {
        private readonly StreamReader _fileStream;

        public FileStreamInput(string testDataFileRelativePath)
        {
            _fileStream = TestDataReader.LoadAsReader(testDataFileRelativePath);
        }

        public void Dispose()
        {
            _fileStream.Close();
        }

        public string ReadLine()
        {
            return _fileStream.ReadLine();
        }
    }
}
