using System;

namespace CodeBox.Core.Exceptions
{
    public class CoreException : InvalidOperationException
    {
        private string _message;
        public override string Message => _message ?? (_message = FormatErrorMessage(GetType().Name));

        public CoreException(string message = null)
        {
            _message = message;
        }

        static string FormatErrorMessage(string message)
        {
            return message.Replace("Exception", "");
        }

    }
}