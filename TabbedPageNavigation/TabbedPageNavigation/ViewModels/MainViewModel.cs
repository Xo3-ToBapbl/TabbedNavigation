using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Navigation;
using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;

namespace TabbedPageNavigation.ViewModels
{
    public class MainViewModel : ViewModelBase /*ITabbedViewModel*/
    {
        public FirstViewModel FirstViewModel { get; private set; }
        public SecondViewModel SecondViewModel { get; private set; }
        public ThirdViewModel FirdViewModel { get; private set; }

        public MainViewModel(INavigationService navigationService)
            : base(navigationService) { }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            this.Log();
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            this.Log();
            base.OnNavigatedTo(parameters);
        }
    }
}
