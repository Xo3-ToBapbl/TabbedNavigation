using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using TabbedPageNavigation.ViewModels;
using TabbedPageNavigation.ViewModels.Base;
using TabbedPageNavigation.Views;

using Xamarin.Forms;

namespace QualityControl.Forms.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public BaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as NavigationPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BaseViewModel;
            }
        }

        public BaseViewModel CurrentPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as NavigationPage;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 1].BindingContext;
                return viewModel as BaseViewModel;
            }
        }

        public Task InitializeAsync()
        {
            return NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public async Task RemoveLastFromBackStackAsync()
        {
            if (Application.Current.MainPage is NavigationPage mainPage)
            {
                var navigationStack = mainPage.Navigation.NavigationStack;
                var previousPage = navigationStack.ElementAtOrDefault(navigationStack.Count - 2);
                if (previousPage != null)
                {
                    mainPage.Navigation.RemovePage(previousPage);
                }
            }

            await Task.FromResult(true);
        }

        public async Task RemoveBackStackAsync()
        {
            if (Application.Current.MainPage is NavigationPage mainPage)
            {
                if (!mainPage.Navigation.NavigationStack.Any())
                    return;

                var lastPage = mainPage.Navigation.NavigationStack.Last();

                while (true)
                {
                    var pageToDelete = mainPage.Navigation.NavigationStack[0];

                    if (pageToDelete != null && pageToDelete != lastPage)
                        mainPage.Navigation.RemovePage(pageToDelete);
                    else
                        break;
                }
            }

            await Task.FromResult(true);
        }

        public async Task GoBackAsync()
        {
            if (Application.Current.MainPage is NavigationPage mainPage)
            {
                await mainPage.PopAsync();
            }
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);

            if (page is MainPage)
            {
                Application.Current.MainPage = new NavigationPage(page);
            }
            else
            {
                if (Application.Current.MainPage is NavigationPage navigationPage)
                {
                    if (navigationPage.Navigation.NavigationStack.Last().GetType() == page.GetType())
                    {
                        return;
                    }
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("ViewModel", "Page");
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}