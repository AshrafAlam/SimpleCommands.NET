using CodeBox.Core.IO;

namespace CodeBox.Console
{
    public class ConsoleOutput : OutputBase
    {
        public ConsoleOutput():base((lineToWrite) => System.Console.WriteLine(lineToWrite))
        {

        }
    }
}