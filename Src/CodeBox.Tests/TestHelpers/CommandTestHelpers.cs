using System.IO;
using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.IO;

namespace ShapeCreator.Tests.TestHelpers
{
    public static class CommandTestHelpers
    {
        public static string ReadFromFile(string dataFilePath)
        {
            var fileText = File.ReadAllText(TestDataPaths.DefaultTestDataFolderPath + "\\" + dataFilePath);
            return fileText;
        }

        internal static IOutput GetOutput(this CommandStreamProcessor canvasCommandStreamProcessor)
        {
            var output = PrivateMemberAccessor.Factory(canvasCommandStreamProcessor, "_output").GetField<IOutput>();
            return output;
        }
    }
}