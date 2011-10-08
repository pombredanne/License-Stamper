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