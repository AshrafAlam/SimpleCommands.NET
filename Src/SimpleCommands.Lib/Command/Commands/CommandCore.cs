
namespace CodeBox.Core.Command.Commands
{
    public abstract class CommandCore : ICommandCore
    {
        protected CommandCore(string name)
        {
            CommandName = name;
        }

        public string CommandName { get; }
 
    }
}