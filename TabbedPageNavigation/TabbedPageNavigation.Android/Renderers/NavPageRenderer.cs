using System.Reflection;
using Android.Content;
using TabbedPageNavigation.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using AToolbar = Android.Support.V7.Widget.Toolbar;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavPageRenderer))]
namespace TabbedPageNavigation.Droid.Renderers
{
    public class NavPageRenderer : NavigationPageRenderer, View.IOnClickListener
    {
        public NavPageRenderer(Context context) : base(context) { }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            var toolbar = typeof(NavigationPageRenderer).GetField("_toolbar",BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this) as AToolbar;
            toolbar.SetNavigationOnClickListener(null);
            toolbar.SetNavigationOnClickListener(new ClickListener());
        }
    }

    public class ClickListener : Java.Lang.Object, View.IOnClickListener
    {
        public void OnClick(View v)
        {

        }
    }
}