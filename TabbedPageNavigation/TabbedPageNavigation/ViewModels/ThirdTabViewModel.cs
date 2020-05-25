using System;
using System.Windows.Input;

using Prism;
using Prism.Navigation;

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

        public ICommand NavigateToNavigationPageCommand { get; }

        public ThirdTabViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
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