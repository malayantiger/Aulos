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
    using Ookii.Dialogs.Wpf;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        private IAlbumLoaderService _albumLoaderService;
        private INavigationService _navigationService;

        public MainWindowViewModel(IAlbumLoaderService albumLoaderService, INavigationService navigationService)
        {
            _albumLoaderService = albumLoaderService;
            _navigationService = navigationService;

            LoadAlbumCommand = new Command(OnLoadAlbumCommandExecute);
            SaveAlbumCommand = new Command(OnSaveAlbumCommandExecute);
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
        public Command SaveAlbumCommand { get; private set; }
        public Command CloseApplicationCommand { get; private set; }

        private void OnLoadAlbumCommandExecute()
        {
            if (Albums == null)
            {
                Albums = new ObservableCollection<AlbumViewModel>();
            }

            var openDialog = new VistaFolderBrowserDialog();
            openDialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;

            if (openDialog.ShowDialog() == true)
            {
                var path = openDialog.SelectedPath;
                var album = _albumLoaderService.Load(path);
                var albumViewModel = album.MapToViewModel();
                Albums.Add(albumViewModel);

                if (Albums.Count > 0)
                {
                    SelectedAlbum = Albums[0];
                }
            }
        }

        public void OnSaveAlbumCommandExecute()
        {
            var album = SelectedAlbum.MapToEntity();
            _albumLoaderService.Save(album);
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
