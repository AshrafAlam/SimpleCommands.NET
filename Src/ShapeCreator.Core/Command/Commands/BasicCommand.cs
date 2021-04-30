
namespace ShapeCreator.Core.Command.Commands
{
    public abstract class BasicCommand : CommandCore, IBasicCommand
    {
        protected BasicCommand(string name) : base(name)
        {

        }

        public abstract void Execute(string[] args);
    }
}