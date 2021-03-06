﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;

using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;
using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class SecondTabViewModel : ViewModelBase, IActiveAware
    {
        private bool isActive;

        public event EventHandler IsActiveChanged;

        public ICommand NavigateToNavigationPageCommand { get; }
        public ICommand SwitchTabCommand { get; }
        public ICommand NavigateToModalPageCommand { get; }

        public bool IsActive 
        { 
            get => isActive;
            set
            {
                SetProperty(ref isActive, value);
                this.Log(isActive.ToString());
            }
        }

        public SecondTabViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
            NavigateToModalPageCommand = new Command(NavigateToModalPage);
            SwitchTabCommand = new Command(SwitchTab);
        }

        private void NavigateToModalPage(object obj)
        {
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ModalView)}", null, true);
        }

        private void SwitchTab(object obj)
        {
            NavigationService.SelectTabAsync(nameof(ThirdTabView));
        }

        private void NavigateToNavigationPage(object obj)
        {
            NavigationService.NavigateAsync(nameof(NonModalView), new NavigationParameters("param=param_second"));
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