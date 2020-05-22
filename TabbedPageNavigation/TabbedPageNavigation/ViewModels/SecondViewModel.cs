using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism;
using Prism.Navigation;
using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;
using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class SecondViewModel : ViewModelBase, IActiveAware
    {
        private bool isActive;

        public event EventHandler IsActiveChanged;

        public ICommand NavigateToNavigationPageCommand { get; }

        public bool IsActive 
        { 
            get => isActive;
            set
            {
                SetProperty(ref isActive, value);
                this.Log(isActive.ToString());
            }
        }

        public SecondViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
        }


        private void NavigateToNavigationPage(object obj)
        {
            NavigationService.NavigateAsync(nameof(NewView), new NavigationParameters("param=param_second"));
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