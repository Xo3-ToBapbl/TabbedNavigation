using System;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace TabbedPageNavigation.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmationDialog : PopupPage
    {
        public event Action OkButtonClick;
        public event Action CancelButtonClick;

        public ConfirmationDialog(string message, string okButtonText="Ok", string cancelButtonText="Cancele")
        {
            InitializeComponent();

            messageLabel.Text = message;
            okButton.Text = okButtonText;
            cancelButton.Text = cancelButtonText;
        }

        private void OkButtonClicked(object sender, EventArgs e)
        {
            OkButtonClick?.Invoke();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            CancelButtonClick?.Invoke();
        }
    }
}