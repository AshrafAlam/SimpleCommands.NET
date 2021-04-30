
using System;

namespace ShapeCreator.Core.Command.Commands
{
    public class QuitCommand : BasicCommand
    {
        public QuitCommand() : base("Q") { }

        public override void Execute(string[] args)
        {
            Environment.Exit(0);
        }
    }
}