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
    public class ThirdViewModel : ViewModelBase, IActiveAware
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

        public ThirdViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
        }

        public event EventHandler IsActiveChanged;

        private void NavigateToNavigationPage(object obj)
        {
            NavigationService.NavigateAsync(nameof(NewView));
        }
    }
}