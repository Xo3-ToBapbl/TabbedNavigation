using System.Net.Http;

using Prism;
using Prism.Common;
using Prism.DryIoc;
using Prism.Ioc;

using Refit;

using TabbedPageNavigation.Extensions;
using TabbedPageNavigation.Interfaces.Services.Api;
using TabbedPageNavigation.ViewModels;
using TabbedPageNavigation.Views;

using Xamarin.Forms;

namespace TabbedPageNavigation
{
    public partial class App 
    {
        public static Page CurrentPage
        {
            get => PageUtilities.GetCurrentPage(Current.MainPage);
        }

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            this.Log();
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainTabView)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainTabView, MainViewModel>();
            containerRegistry.RegisterForNavigation<FirstTabView, FirstTabViewModel>();
            containerRegistry.RegisterForNavigation<SecondTabView, SecondTabViewModel>();
            containerRegistry.RegisterForNavigation<ThirdTabView, ThirdTabViewModel>();
            containerRegistry.RegisterForNavigation<NonModalView, NonModalViewModel>();
            containerRegistry.RegisterForNavigation<ModalView, ModalViewModel>();
        }
    }
}