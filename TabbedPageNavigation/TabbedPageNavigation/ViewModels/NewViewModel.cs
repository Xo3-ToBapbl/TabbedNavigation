using Prism.Navigation;
using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;

namespace TabbedPageNavigation.ViewModels
{
    public class NewViewModel : ViewModelBase
    {
        public NewViewModel(INavigationService navigationService)
            : base(navigationService) { }

        public override void Initialize(INavigationParameters parameters)
        {
            this.Log(parameters.GetValue<string>("param"));
            base.Initialize(parameters);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            this.Log(parameters.GetValue<string>("param"));
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            this.Log(parameters.GetValue<string>("param"));
            base.OnNavigatedTo(parameters);
        }
    }
}