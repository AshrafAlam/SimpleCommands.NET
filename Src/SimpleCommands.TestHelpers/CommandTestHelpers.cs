using System.IO;
using SimpleCommands.Core.Command.Infrastructure;
using SimpleCommands.Core.IO;

namespace SimpleCommands.TestHelpers
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