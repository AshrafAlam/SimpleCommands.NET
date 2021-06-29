using SimpleCommands.Core.IO;

namespace SimpleCommands.App
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}