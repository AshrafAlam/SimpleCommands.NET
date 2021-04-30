namespace ShapeCreator.Core.IO
{
    public interface IOutput
    {
        void WriteLine(string lineToWrite);
        void WriteLine(char[] lineToWrite);
    }
}