using System.Windows.Input;
using Prism.Navigation;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class LaunchViewModel : ViewModelBase
    {
        public ICommand NavigateToNavigationPageCommand { get; }

        public LaunchViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
        }

        private void NavigateToNavigationPage(object obj)
        {
            NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainTabView)}");
        }
    }
}