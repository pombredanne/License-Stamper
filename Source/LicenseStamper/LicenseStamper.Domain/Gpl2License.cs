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
using System.IO;
namespace LicenseStamper.Domain
{
    public sealed class Gpl2License : ILicense
    {
        readonly CopyrightYear _year;
        readonly Projectname _project;

        public Gpl2License(CopyrightYear year, Projectname project)
        {
            if (year == null)
            {
                throw new ArgumentNullException("year");
            }

            if (project == null)
            {
                throw new ArgumentNullException("project");
            }

            _year = year;
            _project = project;
        }

        public void License(IFile file)
        {
            file.AddHeader(GenerateLicenseHeader());
        }

        public void License(IFileContainer container)
        {
            container.CreateFile("LICENSE", GenerateLicenseFile());
        }

        string GenerateLicenseHeader()
        {
            return string.Format(@"﻿/*
 * Copyright (C) {0} {1}
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

", _year.Value, _project.Value);
        }

        string GenerateLicenseFile()
        {
            return File.ReadAllText("GPL2License.txt");
        }
    }
}