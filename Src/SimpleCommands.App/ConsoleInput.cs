using SimpleCommands.Core.IO;

namespace SimpleCommands.Console
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
           return System.Console.ReadLine();
        }
    }
}