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