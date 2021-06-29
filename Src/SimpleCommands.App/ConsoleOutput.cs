using SimpleCommands.Core.IO;

namespace SimpleCommands.App
{
    public class ConsoleOutput : OutputBase
    {
        public ConsoleOutput() : base((lineToWrite) => System.Console.WriteLine(lineToWrite))
        {

        }
    }
}