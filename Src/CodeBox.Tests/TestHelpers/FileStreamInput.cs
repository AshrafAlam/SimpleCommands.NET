using System;
using System.IO;
using CodeBox.Core;
using CodeBox.Core.IO;

namespace CodeBox.Tests.TestHelpers
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
