using System;
using System.Windows.Input;

using Prism;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using TabbedPageNavigation.Enums;
using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.Service;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class ThirdTabViewModel : ViewModelBase, IActiveAware
    {
        private DialogService dialogService;
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

        public ICommand ShowAcceptDialogCommand { get; }
        public ICommand ShowRejectDialogCommand { get; }
        public ICommand ShowActionDialogCommand { get; }
        public ICommand ShowConfirmationDialogCommand { get; }

        public event EventHandler IsActiveChanged;

        public ThirdTabViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
            dialogService = new DialogService();

            ShowAcceptDialogCommand = new Command(ShowAcceptDialog);
            ShowRejectDialogCommand = new Command(ShowRejectDialog);
            ShowActionDialogCommand = new Command(ShowActionDialog);
            ShowConfirmationDialogCommand = new Command(ShowConfirmationDialog);
        }

        private async void ShowConfirmationDialog(object obj)
        {
            bool result = await dialogService.ShowConfirmationDialog("Do you want or not?");
        }

        private async void ShowActionDialog(object obj)
        {
            await dialogService.ShowAlertDialog(DialogTypes.Action, "You have dissmissed the job", 1500);
        }

        private async void ShowRejectDialog(object obj)
        {
            await dialogService.ShowAlertDialog(DialogTypes.Reject, "You rejected the job", 1500);
        }

        private async void ShowAcceptDialog(object obj)
        {
            await dialogService.ShowAlertDialog(DialogTypes.Accept, "You accepted the job", 1500);
        }


        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }
    }
}