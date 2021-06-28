using CodeBox.Core.Command.Commands;
using CodeBox.Core.Command.Infrastructure;
using CodeBox.Core.Exceptions;

namespace CodeBox.Core.Command.Registries
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
