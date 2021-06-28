using CodeBox.Core.IO;

namespace CodeBox.Console
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
           return System.Console.ReadLine();
        }
    }
}