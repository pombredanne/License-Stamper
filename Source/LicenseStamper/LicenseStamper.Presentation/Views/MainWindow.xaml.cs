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

        void ChangeProjectfolderButtonClickEventHandler(object sender, RoutedEventArgs e)
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
