using Aulos.Application.Services;
using Aulos.Core.Application.Services;
using Aulos.Core.Domain.Factories;
using Aulos.Core.Domain.Repositories;
using Aulos.Core.Infrastructure.Services;
using Aulos.Core.Mappers;
using Aulos.Infrastructure.Services;
using Aulos.Infrastructure.Factories;
using Aulos.Infrastructure.Mappers;
using Aulos.Infrastructure.Repositories;
using Aulos.UI.Properties;
using Aulos.UI.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Aulos.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();

            _container.Singleton<IFileProvider, TagLibFileProvider>();
            _container.Singleton<IAlbumFileRepository, AlbumFileRepository>();

            _container.Singleton<IAlbumFactory, AlbumFactory>();
            _container.Singleton<IArtistFactory, ArtistFactory>();

            _container.Singleton<IAlbumDtoMapper, AlbumDtoMapper>();
            _container.Singleton<ITrackDtoMapper, TrackDtoMapper>();
            _container.Singleton<IAlbumFileDtoFactory, AlbumFileDtoFactory>();
            _container.Singleton<ITrackDtoFactory, TrackDtoFactory>();

            _container.PerRequest<IAlbumLoaderService, AlbumLoaderService>();

            _container.Singleton<ShellViewModel, ShellViewModel>("Shell");
            _container.PerRequest<CommandBarViewModel, CommandBarViewModel>();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            var instance = _container.GetInstance(serviceType, key);

            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            Settings.Default.Save();
            base.OnExit(sender, e);
        }
    }
}
