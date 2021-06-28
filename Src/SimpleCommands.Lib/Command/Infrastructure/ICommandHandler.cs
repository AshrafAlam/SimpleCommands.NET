namespace SimpleCommands.Core.Command.Infrastructure
{
    public interface ICommandHandler
    {
        void ExecuteCommand(CommandValues commandValues);
    }
}