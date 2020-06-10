using System;
using System.Windows.Input;

using Prism;
using Prism.Navigation;
using Prism.Services.Dialogs;
using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class ThirdTabViewModel : ViewModelBase, IActiveAware
    {
        private bool isActive;

        public bool IsActive
        {
            get => isActive;
            set
            {
                SetProperty(ref isActive, value);
                this.Log(isActive.ToString());
            }
        }

        private IDialogService dialogService;

        public ICommand NavigateToNavigationPageCommand { get; }
        public ICommand ShowDialogCommand { get; }

        public ThirdTabViewModel(
            INavigationService navigationService,
            IDialogService dialogService)
            : base(navigationService)
        {
            this.dialogService = dialogService;

            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
            ShowDialogCommand = new Command(ShowDialog);
        }

        private void ShowDialog(object obj)
        {
            
        }

        public event EventHandler IsActiveChanged;

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }

        private void NavigateToNavigationPage(object obj)
        {
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ModalView)}", null, true);
        }
    }
}