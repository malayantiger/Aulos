namespace Aulos.CatelUI
{
    using System.Windows;

    using Catel.ApiCop;
    using Catel.ApiCop.Listeners;
    using Catel.IoC;
    using Catel.Logging;
    using Catel.Reflection;
    using Catel.Windows;
    using Aulos.Core.Application.Services;
    using Aulos.Application.Services;
    using Aulos.Core.Infrastructure.Services;
    using Aulos.Infrastructure.Services;
    using Aulos.Infrastructure.Repositories;
    using Aulos.Core.Domain.Repositories;
    using Aulos.Core.Domain.Factories;
    using Aulos.Infrastructure.Factories;
    using Aulos.Infrastructure.Mappers;
    using Aulos.CatelUI.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            LogManager.AddDebugListener();
#endif

            Log.Info("Starting application");

            // To force the loading of all assemblies at startup, uncomment the lines below:

            //Log.Info("Preloading assemblies");
            //AppDomain.CurrentDomain.PreloadAssemblies();


            // Want to improve performance? Uncomment the lines below. Note though that this will disable
            // some features. 
            //
            // For more information, see https://catelproject.atlassian.net/wiki/display/CTL/Performance+considerations

            // Log.Info("Improving performance");
            // Catel.Data.ModelBase.DefaultSuspendValidationValue = true;
            // Catel.Windows.Controls.UserControl.DefaultCreateWarningAndErrorValidatorForViewModelValue = false;
            // Catel.Windows.Controls.UserControl.DefaultSkipSearchingForInfoBarMessageControlValue = true;


            // TODO: Register custom types in the ServiceLocator
            Log.Info("Registering custom types");
            var serviceLocator = ServiceLocator.Default;
            serviceLocator.RegisterType<IFileProvider, TagLibFileProvider>();
            serviceLocator.RegisterType<IAlbumRepository, AlbumFileRepository>();

            serviceLocator.RegisterType<IAlbumFactory, AlbumFactory>();
            serviceLocator.RegisterType<IArtistFactory, ArtistFactory>();

            serviceLocator.RegisterType<ITrackFileFactory, TrackFileFactory>();
            serviceLocator.RegisterType<IAlbumLoaderService, AlbumLoaderService>();

            serviceLocator.RegisterType<AlbumManagerViewModel, AlbumManagerViewModel>();

            //StyleHelper.CreateStyleForwardersForDefaultStyles();

            Log.Info("Calling base.OnStartup");

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Get advisory report in console
            ApiCopManager.AddListener(new ConsoleApiCopListener());
            ApiCopManager.WriteResults();

            base.OnExit(e);
        }
    }
}