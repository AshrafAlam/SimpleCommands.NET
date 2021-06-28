using System.IO;
using CodeBox.Core.Command.Infrastructure;
using CodeBox.Core.IO;

namespace CodeBox.Tests.TestHelpers
{
    public static class CommandTestHelpers
    {
        public static string ReadFromFile(string dataFilePath)
        {
            var fileText = File.ReadAllText(TestDataPaths.DefaultTestDataFolderPath + "\\" + dataFilePath);
            return fileText;
        }

        public static IOutput GetOutput(this CommandStreamProcessor canvasCommandStreamProcessor)
        {
            var output = PrivateMemberAccessor.Factory(canvasCommandStreamProcessor, "_output").GetField<IOutput>();
            return output;
        }
    }
}