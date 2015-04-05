using Aulos.CatelUI.Mappers;
using Aulos.Core.Application.Services;
using Aulos.Core.Domain.Entities;
using Catel.Collections;
using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aulos.CatelUI.ViewModels
{
    public class AlbumManagerViewModel : ViewModelBase
    {
        private readonly IAlbumLoaderService _albumLoaderService;
        private readonly IMessageService _messageService;
        private readonly ISelectDirectoryService _selectDirectoryService;

        public AlbumManagerViewModel(IAlbumLoaderService albumLoaderService, IMessageService messageService, ISelectDirectoryService selectDirectoryService)
        {
            _albumLoaderService = albumLoaderService;
            _messageService = messageService;
            _selectDirectoryService = selectDirectoryService;

            LoadAlbumCommand = new Command(OnLoadAlbumCommandExecute);
            SaveAlbumAsyncCommand = new TaskCommand(OnSaveAlbumAsyncCommandExecute);
            UpdateSourcePathCommand = new Command(OnUpdateSourcePathCommandExecute);
        }

        public ObservableCollection<AlbumViewModel> Albums
        {
            get { return GetValue<ObservableCollection<AlbumViewModel>>(AlbumsProperty); }
            private set { SetValue(AlbumsProperty, value); }
        }

        public AlbumViewModel SelectedAlbum
        {
            get { return GetValue<AlbumViewModel>(SelectedAlbumProperty); }
            set { SetValue(SelectedAlbumProperty, value); }
        }

        public static readonly PropertyData AlbumsProperty = RegisterProperty("Albums", typeof(ObservableCollection<AlbumViewModel>));
        public static readonly PropertyData SelectedAlbumProperty = RegisterProperty("SelectedAlbum", typeof(AlbumViewModel), null, (sender, e) => ((AlbumManagerViewModel)sender).OnSelectedAlbumChanged());

        public ICatelCommand LoadAlbumCommand { get; private set; }
        public ICatelCommand SaveAlbumAsyncCommand { get; private set; }
        public ICatelCommand UpdateSourcePathCommand { get; private set; }

        private void OnLoadAlbumCommandExecute()
        {
            if (Albums == null)
            {
                Albums = new ObservableCollection<AlbumViewModel>();
            }

            if (_selectDirectoryService.DetermineDirectory())
            {
                var path = _selectDirectoryService.DirectoryName;
                var album = _albumLoaderService.Load(path);
                var albumViewModel = album.MapToViewModel();
                Albums.Add(albumViewModel);

                if (Albums.Count > 0)
                {
                    SelectedAlbum = Albums[0];
                }
            }
        }

        public async Task OnSaveAlbumAsyncCommandExecute()
        {
            var album = SelectedAlbum.MapToEntity();
            Exception exception = null;

            try
            {
                _albumLoaderService.Save(album);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            if (exception != null)
                await _messageService.ShowError(exception.Message);
            else
                await _messageService.Show("Album saved!");
        }

        public void OnUpdateSourcePathCommandExecute()
        {
            SelectedAlbum.SourcePath = SelectedAlbum.AlbumTitle;
        }

        private void OnSelectedAlbumChanged()
        {
            int i = 0;
        }
    }
}
