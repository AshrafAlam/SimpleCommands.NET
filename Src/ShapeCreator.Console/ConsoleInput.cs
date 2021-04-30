using ShapeCreator.Core.IO;

namespace ShapeCreator.Console
{
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
           return System.Console.ReadLine();
        }
    }
}