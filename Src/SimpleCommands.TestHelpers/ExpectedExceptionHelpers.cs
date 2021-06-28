using SimpleCommands.Core.Exceptions;
using System;
using Xunit;

namespace SimpleCommands.TestHelpers
{
    public class ExpectedExceptionHelpers
    {
        public static void ExpectException<TException>(Action action,
            TException expectedException)
            where TException : CoreException
        {
            //Act
            var actualException = Assert.Throws<TException>(action);

            //Assert
            Assert.Equal(expectedException.Message, actualException.Message);
        }

        public static void ExpectException<TException>(Action action)
            where TException : CoreException, new()
        {
            ExpectException(action, new TException());
        }

        public static void ExpectExceptionType<TException>(Action action)
            where TException : CoreException
        {
            //Arrange
            var expectedExceptionType = typeof(TException);

            //Act
            var actualException = Assert.Throws<TException>(action);

            //Get actual excedption type
            var actualExceptionType = actualException.GetType();

            //Assert
            Assert.True(expectedExceptionType == actualExceptionType);
        }
    }
}
