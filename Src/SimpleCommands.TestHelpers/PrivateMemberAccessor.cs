using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCommands.TestHelpers
{
    public class PrivateMemberAccessor
    {
        private readonly object _target;
        private readonly string _memberName;
        private PrivateObject _privateObject;

        private PrivateObject PrivateObject => _privateObject ?? (_privateObject = new PrivateObject(_target));

        public PrivateMemberAccessor(object target, string memberName)
        {
            _target = target;
            _memberName = memberName;
        }

        public static PrivateMemberAccessor Factory(object target, string memberName)
        {
            return new PrivateMemberAccessor(target, memberName);
        }

        public T GetField<T>()
        {
            return (T) PrivateObject.GetField(_memberName);
        }

        public T GetProperty<T>()
        {
            return (T) PrivateObject.GetProperty(_memberName);
        }
    }
}
