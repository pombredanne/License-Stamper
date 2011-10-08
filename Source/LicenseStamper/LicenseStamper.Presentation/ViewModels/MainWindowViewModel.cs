using LicenseStamper.Presentation.Models;
using System.Windows.Input;
namespace LicenseStamper.Presentation.ViewModels
{
    public sealed class MainWindowViewModel
    {
        readonly IFileContainerModel _filecontainer;
        readonly ICommand _licenseFolderCommand;

        public MainWindowViewModel(IFileContainerModel filecontainer)
        {
            _filecontainer = filecontainer;
            _licenseFolderCommand = new RelayCommand(_ => _filecontainer.License(), _ => _filecontainer.CanLicense());
        }

        public IFileContainerModel Filecontainer
        {
            get
            {
                return _filecontainer;
            }
        }

        public ICommand LicenseFolderCommand
        {
            get
            {
                return _licenseFolderCommand;
            }
        }
    }
}