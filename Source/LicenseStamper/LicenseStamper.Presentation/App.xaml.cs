using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using LicenseStamper.Presentation.Views;
using LicenseStamper.Presentation.ViewModels;
using LicenseStamper.Presentation.Models;

namespace LicenseStamper.Presentation
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();
            window.DataContext = new MainWindowViewModel(new FolderModel());
            window.Show();
        }
    }
}
