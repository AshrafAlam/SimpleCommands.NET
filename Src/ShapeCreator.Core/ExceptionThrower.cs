using ShapeCreator.Core.Exceptions;

namespace ShapeCreator.Core
{
    public class ExceptionThrower
    {

        public static void Throws<T>()
            where T : DrawingException, new()
        {
            throw new T();
        }
        
    }
}