using Prism;
using Prism.Ioc;
using TabbedPageNavigation.ViewModels;
using TabbedPageNavigation.Views.Dialogs;

namespace TabbedPageNavigation.Droid.Initializer
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Override the name used to call the dialog
            containerRegistry.RegisterDialog<DemoDialog, DemoDialogViewModel>("DemoDialog");
        }
    }
}