using System.Collections.Generic;
using CodeBox.Core.Command.Commands;

namespace CodeBox.Core.Command.Registries
{

    public abstract class CommandRegistryBase<T>
        where T : ICommandCore
    {
        protected readonly Dictionary<string, T> RegistryDictionary;

        protected CommandRegistryBase()
        {
            RegistryDictionary = new Dictionary<string, T>();
        }

        protected CommandRegistryBase(params T[] commands)
            : this()
        {
            foreach (var command in commands)
                RegisterCommand(command);
        }

        public void RegisterCommand(T command)
        {
            RegistryDictionary.Add(command.CommandName, command);
        }
    }
}
