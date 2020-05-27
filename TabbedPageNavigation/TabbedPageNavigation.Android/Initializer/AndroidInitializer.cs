using System.Net.Http;

using Prism;
using Prism.Ioc;

using Xamarin.Android.Net;

namespace TabbedPageNavigation.Droid.Initializer
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<HttpMessageHandler>(new AndroidClientHandler());
        }
    }
}