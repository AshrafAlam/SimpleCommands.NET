using ShapeCreator.Core.IO;

namespace ShapeCreator.Console
{
    public class ConsoleOutput : OutputBase
    {
        public ConsoleOutput():base((lineToWrite) => System.Console.WriteLine(lineToWrite))
        {

        }
    }
}