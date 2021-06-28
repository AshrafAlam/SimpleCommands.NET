namespace ShapeCreator.Core.IO
{
    public abstract class OutputBase : IOutput
    {
        public abstract void WriteLine(char[] lineToWrite);
        
        public void WriteLine(string lineToWrite)
        {
            WriteLine(lineToWrite.ToCharArray());
        }
    }
}