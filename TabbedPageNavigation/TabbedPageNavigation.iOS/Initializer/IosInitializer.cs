using Prism;
using Prism.Ioc;
using TabbedPageNavigation.ViewModels;
using TabbedPageNavigation.Views.Dialogs;

namespace TabbedPageNavigation.iOS.Initializer
{
    public class IosInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DemoDialog, DemoDialogViewModel>("DemoDialog");
        }
    }
}