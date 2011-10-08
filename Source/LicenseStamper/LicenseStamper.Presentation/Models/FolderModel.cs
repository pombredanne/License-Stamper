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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using LicenseStamper.Domain;

namespace LicenseStamper.Presentation.Models
{
    public sealed class FolderModel : INotifyPropertyChanged, IFileContainerModel
    {
        readonly ObservableCollection<string> _licensingProgress;
        IFileContainer _currentContainer;
        string _projectname;
        int _copyrightYear;
        string _projectfolder;

        public FolderModel()
        {
            _licensingProgress = new ObservableCollection<string>();
        }

        public ObservableCollection<string> LicensingProgress
        {
            get
            {
                return _licensingProgress;
            }
        }

        public string Projectname
        {
            get
            {
                return _projectname;
            }
            set
            {
                _projectname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Projectname"));
            }
        }

        public string CopyrightYear
        {
            get
            {
                return _copyrightYear.ToString();
            }
            set
            {
                _copyrightYear = int.Parse(value);
                PropertyChanged(this, new PropertyChangedEventArgs("CopyrightYear"));
            }
        }

        public string Projectfolder
        {
            get
            {
                return _projectfolder;
            }
            set
            {
                _projectfolder = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Projectfolder"));
            }
        }

        public void License()
        {
            if (_currentContainer != null)
            {
                RemovePreviousContainer();
            }

            AssignNewContainer(_projectfolder);

            Task.Factory.StartNew(() =>
                {
                    _currentContainer.LicenseFiles(new Gpl2License(new CopyrightYear(_copyrightYear), new Projectname(_projectname)));
                });
        }

        public bool CanLicense()
        {
            return !string.IsNullOrWhiteSpace(_projectfolder) && !string.IsNullOrWhiteSpace(_projectname);
        }

        void AssignNewContainer(string folderpath)
        {
            _currentContainer = new Folder(folderpath);
            _currentContainer.FileLicensed += FileLicensedEventHandler;
            _currentContainer.FileLicensingStarted += FileLicensingStartedEventHandler;
        }

        void RemovePreviousContainer()
        {
            _currentContainer.FileLicensed -= FileLicensedEventHandler;
            _currentContainer.FileLicensingStarted -= FileLicensingStartedEventHandler;
        }

        void FileLicensingStartedEventHandler(object sender, EventArgs<string> e)
        {
            UpdateProgress(e.Value);
        }

        void FileLicensedEventHandler(object sender, EventArgs<string> e)
        {
            UpdateProgress(e.Value);
        }

        void UpdateProgress(string message)
        {
            Application.Current.Dispatcher.Invoke(new Action<string>(value => _licensingProgress.Add(value)), message);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}