using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism;
using Prism.Common;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services.Dialogs;
using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;
using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class SecondTabViewModel : ViewModelBase, IActiveAware
    {
        private readonly IDialogService _dialogService;

        private bool isActive;
        
        public event EventHandler IsActiveChanged;

        public ICommand NavigateToNavigationPageCommand { get; }
        public ICommand SwitchTabCommand { get; }
        public ICommand ShowDialogCommand { get; }
        
        public bool IsActive 
        { 
            get => isActive;
            set
            {
                SetProperty(ref isActive, value);
                this.Log(isActive.ToString());
            }
        }

        public SecondTabViewModel(INavigationService navigationService,
                                  IDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
            SwitchTabCommand = new Command(SwitchTab);
            ShowDialogCommand = new Command(ShowDialog);
        }

        private void ShowDialog()
        {
            var parameters = new DialogParameters
            {
                { "title", "Connection Lost!" },
                { "message", "We seem to have lost network connectivity" }
            };
            var result = _dialogService.ShowDialogAsync("DemoDialog", parameters);
        }

        private void SwitchTab(object obj)
        {
            NavigationService.SelectTabAsync(nameof(ThirdTabView));
        }

        private void NavigateToNavigationPage(object obj)
        {
            NavigationService.NavigateAsync(nameof(NonModalView), new NavigationParameters("param=param_second"));
        }

        public override void Initialize(INavigationParameters parameters)
        {
            this.Log();
            base.Initialize(parameters);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            this.Log();
            base.OnNavigatedTo(parameters);
        }
    }
}