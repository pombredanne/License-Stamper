using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LicenseStamper.Presentation.Models
{
    public interface IFileContainerModel
    {
        ObservableCollection<string> LicensingProgress { get; }
        string Projectname { get; set; }
        string CopyrightYear { get; set; }
        string Projectfolder { get; set; }
        bool CanLicense();
        void License();
        event PropertyChangedEventHandler PropertyChanged;
    }
}