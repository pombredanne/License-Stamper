using System;
namespace LicenseStamper.Domain
{
    public sealed class CopyrightYear
    {
        readonly int _value;

        public CopyrightYear(int value)
        {
            if (value < 1900 || value > 3000)
            {
                throw new ArgumentOutOfRangeException("value", "Invalid value given. Value must be between 1900 and 3000");
            }

            _value = value;
        }

        public int Value
        {
            get
            {
                return _value;
            }
        }
    }
}