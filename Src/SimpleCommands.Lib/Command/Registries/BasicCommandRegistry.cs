using SimpleCommands.Core.Command.Commands;
using SimpleCommands.Core.Command.Infrastructure;
using SimpleCommands.Core.Exceptions;

namespace SimpleCommands.Core.Command.Registries
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
