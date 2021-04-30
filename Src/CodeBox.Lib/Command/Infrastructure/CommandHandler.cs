using System;
using System.Collections.Generic;
using ShapeCreator.Core.Command.Commands;
using ShapeCreator.Core.Command.Registries;
using ShapeCreator.Core.Exceptions;
using ShapeCreator.Core.IO;

namespace ShapeCreator.Core.Command.Infrastructure
{
    public class CommandHandler
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

        private DrawInCanvasCommandRegistry<DrawObjectCommand> _drawInCanvasCommandRegistry;

        private DrawInCanvasCommandRegistry<DrawObjectCommand> DrawInCanvasCommandRegistry =>
            _drawInCanvasCommandRegistry ?? (_drawInCanvasCommandRegistry =
                new DrawInCanvasCommandRegistry<DrawObjectCommand>(
                    new DrawLineCommand(),
                    new DrawRectangleCommand(),
                    new DrawBucketFillCommand()));


        private Canvas _canvas;

        private Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                    ExceptionThrower.Throws<CanvasMustBeCreatedFirstException>();

                return _canvas;
            }

            set => _canvas = value;
        }

        CommandType GetCommandType(string commandName)
        {
            if (CommandTypeDictionary.ContainsKey(commandName))
                return CommandTypeDictionary[commandName];

            throw new InvalidCommandException(commandName);
        }

        private Dictionary<string, CommandType> _commandTypeDictionary;

        private Dictionary<string, CommandType> CommandTypeDictionary => _commandTypeDictionary ?? (_commandTypeDictionary = new Dictionary<string, CommandType>
        {
            {"L", CommandType.DrawInCanvas},
            {"R", CommandType.DrawInCanvas},
            {"B", CommandType.DrawInCanvas},
            {"C", CommandType.CreateCanvas},
            {"H", CommandType.Basic},
            {"Q", CommandType.Basic}
        });
        
        public void ExecuteCommand(CommandValues commandValues)
        {
            CommandType commandType = GetCommandType(commandValues.CommandName);

            switch (commandType)
            {
                case CommandType.CreateCanvas:
                    Canvas = new CanvasCreationCommand(_output).CreateCommand(commandValues.CommandArgs);
                    Canvas.Render();
                    break;
                case CommandType.DrawInCanvas:
                    DrawInCanvasCommandRegistry.Execute(commandValues, Canvas);
                    Canvas.Render();
                    break;
                case CommandType.Basic:
                    BasicCommandRegistry.Execute(commandValues);
                    break;
            }
        }

    }
}