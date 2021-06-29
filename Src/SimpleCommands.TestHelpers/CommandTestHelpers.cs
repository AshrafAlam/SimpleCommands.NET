using SimpleCommands.Core.Command.Infrastructure;
using SimpleCommands.Core.IO;
using System.IO;

namespace SimpleCommands.TestHelpers
{
    public static class CommandTestHelpers
    {
        public static IOutput GetOutput(this CommandStreamProcessor canvasCommandStreamProcessor)
        {
            var output = PrivateMemberAccessor.Factory(canvasCommandStreamProcessor, "_output").GetField<IOutput>();
            return output;
        }
    }
}