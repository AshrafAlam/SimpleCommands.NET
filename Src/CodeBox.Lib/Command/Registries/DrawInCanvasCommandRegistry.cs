using ShapeCreator.Core.Command.Commands;
using ShapeCreator.Core.Command.Infrastructure;
using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core.Command.Registries
{

    public class DrawInCanvasCommandRegistry<T>
        : CommandRegistryBase<T>
        where T : DrawObjectCommand
    {
        public DrawInCanvasCommandRegistry(params T[] commands)
            : base(commands)
        {

        }

        public void Execute(CommandValues commandValues, Canvas canvas)
        {
            if (RegistryDictionary.ContainsKey(commandValues.CommandName))
                RegistryDictionary[commandValues.CommandName].Execute(canvas, commandValues.CommandArgs);
            else
                throw new InvalidCommandException(commandValues.CommandName);

        }
    }
}
