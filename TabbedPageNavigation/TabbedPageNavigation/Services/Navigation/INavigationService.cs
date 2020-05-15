﻿using System.Threading.Tasks;
using TabbedPageNavigation.ViewModels.Base;

namespace QualityControl.Forms.Services.Navigation
{
    public interface INavigationService
    {
        BaseViewModel PreviousPageViewModel { get; }

        BaseViewModel CurrentPageViewModel { get; }

        /// <summary>
        /// Performs navigation to one of two pages when the app is launched.
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Performs hierarchical navigation to a specified page.
        /// </summary>
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        /// <summary>
        /// Performs hierarchical navigation to a specified page, passing a parameter.
        /// </summary>
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        /// <summary>
        /// Removes the previous page from the navigation stack.
        /// </summary>
        Task RemoveLastFromBackStackAsync();

        /// <summary>
        /// Removes all the previous pages from the navigation stack.
        /// </summary>
        Task RemoveBackStackAsync();

        Task GoBackAsync();
    }
}