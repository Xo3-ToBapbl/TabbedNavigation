using System.Threading.Tasks;

using QualityControl.Forms.Services.Navigation;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels.Base
{
    public abstract class BaseViewModel : BindableObject
    {
        protected readonly INavigationService NavigationService;

        protected BaseViewModel()
        {
            NavigationService = new NavigationService();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }

        public virtual async Task GoBackAsync()
        {
            await NavigationService.GoBackAsync();
        }
    }
}