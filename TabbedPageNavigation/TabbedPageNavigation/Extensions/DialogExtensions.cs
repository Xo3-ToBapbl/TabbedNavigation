using System;
using System.Collections.Generic;
using System.Text;
using Prism.Services.Dialogs;
using TabbedPageNavigation.Views;
using Xamarin.Forms;

namespace TabbedPageNavigation.Extensions
{
    public static class DialogExtension
    {
        public static void ShowErrorMessage(this IDialogService dialogService, string message)
        {
            dialogService.ShowDialog(nameof(PrismDialogView), new DialogParameters
           {
               {"message" , message },
               {"backgroundColor", Color.FromHex("#D0021B") }
           });
        }

        public static void ShowInformationMessage(this IDialogService dialogService, string message)
        {
            dialogService.ShowDialog(nameof(PrismDialogView), new DialogParameters
           {
               {"message" , message },
               {"backgroundColor", Color.FromHex("#002232") }
           });
        }

        public static void ShowSuccessMessage(this IDialogService dialogService, string message)
        {
            dialogService.ShowDialog(nameof(PrismDialogView), new DialogParameters
           {
               {"message" , message },
               {"backgroundColor", Color.FromHex("#7AB800") }
           });
        }
    }
}
