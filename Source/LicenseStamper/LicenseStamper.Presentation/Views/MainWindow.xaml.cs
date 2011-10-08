using System.Windows;
using LicenseStamper.Presentation.ViewModels;
using System.Windows.Forms;

namespace LicenseStamper.Presentation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeProjectfolderButtonClickEventHandler(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel vm = (MainWindowViewModel)DataContext;

            using (FolderBrowserDialog projectfolderDialog = new FolderBrowserDialog())
            {
                projectfolderDialog.Description = "Choose your project folder.";
                projectfolderDialog.SelectedPath = vm.Filecontainer.Projectfolder;

                if (projectfolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    vm.Filecontainer.Projectfolder = projectfolderDialog.SelectedPath;
                }
            }
        }
    }
}
