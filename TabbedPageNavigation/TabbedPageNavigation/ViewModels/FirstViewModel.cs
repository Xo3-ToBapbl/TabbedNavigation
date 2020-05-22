﻿using System;
using System.Collections.Generic;
using System.Windows.Input;

using Prism;
using Prism.Navigation;

using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels
{
    public class FirstViewModel : ViewModelBase, IActiveAware
    {
        private bool isActive;

        public IList<int> Indexes { get; }

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

        public FirstViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Indexes = new List<int>(50);
            for (int i = 0; i < 50; i++)
                Indexes.Add(i);

            NavigateToNavigationPageCommand = new Command(NavigateToNavigationPage);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
        }

        private void NavigateToNavigationPage(object obj)
        {
            this.Log();
            NavigationService.NavigateAsync(nameof(NewView));
        }

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