using System;
using System.IO;
using System.Reflection;

namespace SimpleCommands.TestHelpers
{
    public class TestDataReader
    {
        public static string LoadAsString(string testDataFileRelativePath,
            string parentFolder = TestDataPaths.DefaultTestDataFolderPath)
        {
            return File.ReadAllText(GetFullFilePathFromCodebase(testDataFileRelativePath));
        }

        public static StreamReader LoadAsReader(string testDataFileRelativePath,
            string parentFolder = TestDataPaths.DefaultTestDataFolderPath)
        {
            return new StreamReader(GetFullFilePathFromCodebase(testDataFileRelativePath));
        }

        public static string GetFullFilePathFromCodebase(string testDataFileRelativePath,
            string parentFolder = TestDataPaths.DefaultTestDataFolderPath)
        {
            if (!string.IsNullOrEmpty(parentFolder))
                testDataFileRelativePath = parentFolder + "\\" + testDataFileRelativePath;

            var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var targetDirPath = Path.GetDirectoryName(codeBasePath);
            var fullPath = Path.Combine(targetDirPath ??
                                        throw new InvalidOperationException($"{testDataFileRelativePath} not found."),
                testDataFileRelativePath);

            return fullPath;

        }
    }
}
