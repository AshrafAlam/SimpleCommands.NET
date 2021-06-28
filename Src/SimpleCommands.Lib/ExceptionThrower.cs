using SimpleCommands.Core.Exceptions;

namespace SimpleCommands.Core
{
    public class ExceptionThrower
    {

        public static void Throws<T>()
            where T : CommandException, new()
        {
            throw new T();
        }

    }
}