/*
 * Copyright (C) 2011 License Stamper
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

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