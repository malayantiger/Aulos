using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aulos.CatelUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IUIVisualizerService _uiVisualizerService;

        public MainWindowViewModel(INavigationService navigationService, IUIVisualizerService uiVisualizerService)
        {
            _navigationService = navigationService;
            _uiVisualizerService = uiVisualizerService;
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

        public ICatelCommand OpenAlbumCommand { get; private set; }
        public ICatelCommand CloseApplicationCommand { get; private set; }

        private void OnOpenAlbumCommandExecute()
        {
            
        }

        private void OnCloseApplicationCommandExecute()
        {
            _navigationService.CloseApplication();
        }
    }
}
