using ShapeCreator.Core.IO;

namespace ShapeCreator.Console
{
    public class ConsoleOutput : OutputBase
    {
        public override void WriteLine(char[] lineToWrite)
        {
            System.Console.WriteLine(lineToWrite);
        }
    }
}