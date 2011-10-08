using System;
namespace LicenseStamper.Domain
{
    public interface IFileContainer
    {
        void CreateFile(string filepath, string content);
        void LicenseFiles(ILicense license);

        event EventHandler<EventArgs<string>> FileLicensingStarted;
        event EventHandler<EventArgs<string>> FileLicensed;
    }
}