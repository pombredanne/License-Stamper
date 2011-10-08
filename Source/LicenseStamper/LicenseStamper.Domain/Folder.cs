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

using System.IO;
using System;
namespace LicenseStamper.Domain
{
    public sealed class Folder : IFileContainer
    {
        readonly string _path;

        public Folder(string path)
        {
            _path = path;
        }

        public void LicenseFiles(ILicense license)
        {
            LicenseContainer(license);
            foreach (string csharpFilename in GetFilesToBeLicensed())
            {
                LicenseFile(license, csharpFilename);
            }
        }

        public void CreateFile(string filepath, string content)
        {
            File.WriteAllText(CreateAbsoluteFilepath(filepath), content);
        }

        void LicenseContainer(ILicense license)
        {
            license.License(this);
        }

        void LicenseFile(ILicense license, string licenseFilename)
        {
            RaiseFileLicensingStartedEvent(licenseFilename);

            CSharpfile file = new CSharpfile(licenseFilename);
            license.License(file);

            RaiseFileLicensedEvent(licenseFilename);
        }

        string[] GetFilesToBeLicensed()
        {
            return Directory.GetFiles(_path, "*.cs", SearchOption.AllDirectories);
        }

        string CreateAbsoluteFilepath(string filepathRelativeToContainer)
        {
            return Path.Combine(_path, filepathRelativeToContainer);
        }

        void RaiseFileLicensingStartedEvent(string licenseFilename)
        {
            FileLicensingStarted(this, new EventArgs<string>(licenseFilename));
        }

        void RaiseFileLicensedEvent(string licensedFilename)
        {
            FileLicensed(this, new EventArgs<string>(licensedFilename));
        }

        public event EventHandler<EventArgs<string>> FileLicensingStarted = delegate { };
        public event EventHandler<EventArgs<string>> FileLicensed = delegate { };
    }
}