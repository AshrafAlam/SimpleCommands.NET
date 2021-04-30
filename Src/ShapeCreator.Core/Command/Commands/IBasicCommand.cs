namespace ShapeCreator.Core.Command.Commands
{
    public interface IBasicCommand:ICommandCore
    {
        void Execute(string[] args);
    }
}