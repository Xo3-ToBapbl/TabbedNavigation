using Rg.Plugins.Popup.Services;

using TabbedPageNavigation.Extensions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdTabView : ContentPage
    {
        public ThirdTabView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new DialogPage());
        }
    }
}