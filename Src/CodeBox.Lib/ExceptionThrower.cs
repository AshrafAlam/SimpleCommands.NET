using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core
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