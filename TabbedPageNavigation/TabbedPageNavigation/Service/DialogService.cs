using System;
using System.Threading.Tasks;
using System.Timers;

using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Events;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using TabbedPageNavigation.Enums;
using TabbedPageNavigation.Views.Dialogs;

using Xamarin.Forms;

namespace TabbedPageNavigation.Service
{
    public class DialogService
    {
        private IPopupNavigation popupNavigation => PopupNavigation.Instance;

        public async Task ShowAlertDialog(DialogTypes dialogType, string message, int dissmissAfter=0)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            PopupPage page = InitializePage(dialogType, message);

            var timer = new Timer(dissmissAfter);
            timer.Elapsed += CloseDialog;

            popupNavigation.Popped += Popped;
            await popupNavigation.PushAsync(page);

            timer.Start();

            await taskCompletionSource.Task;

            void Popped(object sender, PopupNavigationEventArgs e)
            {
                popupNavigation.Popped -= Popped;
                timer.Elapsed -= CloseDialog;
                timer.Stop();
                timer.Dispose();

                taskCompletionSource.TrySetResult(default(object));
            }
        }

        private async void CloseDialog(object sender, ElapsedEventArgs e)
        {
            if (sender is Timer timer)
                timer.Stop();

            await popupNavigation.PopAsync();
        }

        private PopupPage InitializePage(DialogTypes dialogType, string message)
        {
            switch (dialogType)
            {
                case DialogTypes.Accept:
                    return new AlertDialog(Color.Green, message);
                case DialogTypes.Reject:
                    return new AlertDialog(Color.Red, message);
                case DialogTypes.Action:
                    return new AlertDialog(Color.DarkBlue, message);
            }

            throw new TypeInitializationException(dialogType.ToString(), null);
        }
    }
}