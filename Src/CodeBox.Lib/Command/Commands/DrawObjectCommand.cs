
namespace ShapeCreator.Core.Command.Commands
{
    public abstract class DrawObjectCommand: CommandCore
    {
        protected DrawObjectCommand(string name):base(name)
        {
            
        }

        public abstract void Execute(Canvas canvas, string[] args);
    }
}