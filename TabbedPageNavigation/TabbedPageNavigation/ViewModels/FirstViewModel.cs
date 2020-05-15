using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class FirstViewModel
    {
        public ICommand NavigateToNavigationPageCommand { get; }

        public FirstViewModel()
        {
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
        }

        private void NavigateToNavigationPage(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
