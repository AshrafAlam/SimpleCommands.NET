using ShapeCreator.Core.Command.Commands;
using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core.Command.Registries
{

    public class BasicCommandRegistry<T> :
        CommandRegistryBase<T> where T : IBasicCommand
    {
        public BasicCommandRegistry(params T[] commands) : base(commands)
        {

        }

        public void Execute(CommandValues commandValues)
        {
            if (RegistryDictionary.ContainsKey(commandValues.CommandName))
                RegistryDictionary[commandValues.CommandName].Execute(commandValues.CommandArgs);
            else
                throw new InvalidCommandException(commandValues.CommandName);

        }
    }
}
