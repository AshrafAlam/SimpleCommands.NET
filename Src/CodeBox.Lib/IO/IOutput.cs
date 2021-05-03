namespace ShapeCreator.Core.IO
{
    public interface IOutput
    {
        void WriteLineWithTrack(string lineToWrite);
        void WriteLine(char[] lineToWrite);
    }
}