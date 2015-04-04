namespace Aulos.CatelUI.ViewModels
{
    using Aulos.CatelUI.Mappers;
    using Aulos.Core.Application.Services;
    using Aulos.Core.Domain.Entities;
    using Catel.Collections;
    using Catel.Data;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IAlbumLoaderService _albumLoaderService;
        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly ISelectDirectoryService _selectDirectoryService;

        public MainWindowViewModel(IAlbumLoaderService albumLoaderService, INavigationService navigationService, IMessageService messageService, ISelectDirectoryService selectDirectoryService)
        {
            _albumLoaderService = albumLoaderService;
            _navigationService = navigationService;
            _messageService = messageService;
            _selectDirectoryService = selectDirectoryService;

            LoadAlbumCommand = new Command(OnLoadAlbumCommandExecute);
            SaveAlbumAsyncCommand = new TaskCommand(OnSaveAlbumAsyncCommandExecute);
            CloseApplicationCommand = new Command(OnCloseApplicationCommandExecute);
        }

        public override string Title { get { return "Aulos.CatelUI"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task Initialize()
        {
            await base.Initialize();

            // TODO: subscribe to events here
        }

        protected override async Task Close()
        {
            // TODO: unsubscribe from events here

            await base.Close();
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
        public static readonly PropertyData SelectedAlbumProperty = RegisterProperty("SelectedAlbum", typeof(AlbumViewModel), null, (sender, e) => ((MainWindowViewModel)sender).OnSelectedAlbumChanged());

        public Command LoadAlbumCommand { get; private set; }
        public TaskCommand SaveAlbumAsyncCommand { get; private set; }
        public Command CloseApplicationCommand { get; private set; }

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

        private void OnSelectedAlbumChanged()
        {
            int i = 0;
        }

        private void OnCloseApplicationCommandExecute()
        {
            _navigationService.CloseApplication();
        }
    }
}
