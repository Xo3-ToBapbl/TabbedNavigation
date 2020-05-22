using System.Threading.Tasks;

using QualityControl.Forms.Services.Navigation;

using TabbedPageNavigation.Services.DependencyResolver;
using TabbedPageNavigation.Services.Ioc;

using Xamarin.Forms;

using Prism;
using Prism.Ioc;
using TabbedPageNavigation.Views;
using TabbedPageNavigation.ViewModels;
using TabbedPageNavigation.Extensions;

namespace TabbedPageNavigation
{
    public partial class App 
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            this.Log();
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainView)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<FirstView, FirstViewModel>();
            containerRegistry.RegisterForNavigation<SecondView, SecondViewModel>();
            containerRegistry.RegisterForNavigation<ThirdView, ThirdViewModel>();
            containerRegistry.RegisterForNavigation<NewView, NewViewModel>();
        }
    }
}