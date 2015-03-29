using Aulos.Core.Application.Services;
using Aulos.UI.Properties;
using Caliburn.Micro;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aulos.UI.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShell
    {
        private IAlbumLoaderService _albumLoader;

        public CommandBarViewModel CommandBar { get; private set; }

        public ShellViewModel(CommandBarViewModel commandBar, IAlbumLoaderService albumLoader)
        {
            CommandBar = commandBar;
            _albumLoader = albumLoader;
        }

        public void OpenAlbum()
        {
            var openDialog = new VistaFolderBrowserDialog();
            openDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;

            if (openDialog.ShowDialog() == true)
            {
                var path = openDialog.SelectedPath;
                var album = _albumLoader.Load(path);

                var albumViewModel = new AlbumViewModel()
                    {
                        Artist = album.Artist.Name,
                        Title = album.Title,
                        Path = album.SourcePath
                    };
                ActivateItem(albumViewModel);
            }
        }
    }
}

