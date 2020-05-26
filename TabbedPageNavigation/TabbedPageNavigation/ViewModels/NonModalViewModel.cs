﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Prism.Navigation;

using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class NonModalViewModel : ViewModelBase, IConfirmNavigation
    {
        public string Value => $"This is New Navigation Page {DateTime.Now.Second}";

        public ICommand NavigateToNavigationPageCommand { get; }

        public NonModalViewModel(INavigationService navigationService)
            : base(navigationService) 
        {
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            this.Log(parameters.GetValue<string>("param"));
            base.Initialize(parameters);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        public override Task<INavigationResult> NavigateBack(INavigationParameters parameters = null, bool? modalNavigation = null, bool animated = true)
        {
            return base.NavigateBack(new NavigationParameters("param=backward"), modalNavigation, animated);
        }

        public bool CanNavigate(INavigationParameters parameters)
        {
            this.Log();
            return true;
        }

        private void NavigateToNavigationPage(object obj)
        {
            NavigationService.NavigateAsync(nameof(NonModalView), new NavigationParameters("param=forward"));
        }
    }
}