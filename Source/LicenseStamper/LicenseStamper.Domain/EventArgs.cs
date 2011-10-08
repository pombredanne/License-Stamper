using System;
namespace LicenseStamper.Domain
{
    public sealed class EventArgs<T> : EventArgs
    {
        readonly T _value;

        public EventArgs(T value)
        {
            _value = value;
        }

        public T Value
        {
            get
            {
                return _value;
            }
        }
    }
}