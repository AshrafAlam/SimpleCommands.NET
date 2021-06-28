using System.Collections.Generic;
using CodeBox.Core.Command.Commands;
using CodeBox.Core.Command.Registries;
using CodeBox.Core.Exceptions;
using CodeBox.Core.IO;

namespace CodeBox.Core.Command.Infrastructure
{
    public class CommandHandler:ICommandHandler
    {
        private readonly IOutput _output;

        public CommandHandler(IOutput output)
        {
            _output = output;
        }

        private BasicCommandRegistry<BasicCommand> _basicCommandRegistry;

        private BasicCommandRegistry<BasicCommand> BasicCommandRegistry =>
            _basicCommandRegistry ?? (_basicCommandRegistry = new BasicCommandRegistry<BasicCommand>(
                new QuitCommand(),
                new HelloCommand(_output)));

        CommandType GetCommandType(string commandName)
        {
            if (CommandTypeDictionary.ContainsKey(commandName))
                return CommandTypeDictionary[commandName];

            throw new InvalidCommandException(commandName);
        }

        private Dictionary<string, CommandType> _commandTypeDictionary;

        private Dictionary<string, CommandType> CommandTypeDictionary => _commandTypeDictionary ?? (_commandTypeDictionary = new Dictionary<string, CommandType>
        {
            {"H", CommandType.Basic},
            {"Q", CommandType.Basic}
        });
        
        public void ExecuteCommand(CommandValues commandValues)
        {
            CommandType commandType = GetCommandType(commandValues.CommandName);

            switch (commandType)
            {
                case CommandType.Basic:
                    BasicCommandRegistry.Execute(commandValues);
                    break;
            }
        }

    }
}