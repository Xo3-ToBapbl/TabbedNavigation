using Rg.Plugins.Popup.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageNavigation.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertDialog : PopupPage
    {
        public AlertDialog(Color backgroundColor, string message)
        {
            InitializeComponent();

            contentStack.BackgroundColor = backgroundColor;
            messageLabel.Text = message;
        }
    }
}