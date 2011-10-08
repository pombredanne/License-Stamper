namespace LicenseStamper.Domain
{
    public interface ILicense
    {
        void License(IFile file);
        void License(IFileContainer container);
    }
}