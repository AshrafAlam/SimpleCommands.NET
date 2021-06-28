using CodeBox.Core.Exceptions;

namespace CodeBox.Core
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