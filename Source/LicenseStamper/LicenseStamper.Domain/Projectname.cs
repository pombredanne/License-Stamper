using System;
namespace LicenseStamper.Domain
{
    public sealed class Projectname
    {
        readonly string _value;

        public Projectname(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("value");
            }

            _value = value;
        }

        public string Value
        {
            get
            {
                return _value;
            }
        }
    }
}