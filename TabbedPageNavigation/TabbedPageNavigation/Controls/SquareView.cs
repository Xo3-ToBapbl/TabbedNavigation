using System;
using System.Collections.Generic;
using System.Text;

using TabbedPageNavigation.Extensions;

using Xamarin.Forms;

namespace TabbedPageNavigation.Controls
{
    public class SquareView : ContentView
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            this.Log($"{width} {height}");
            base.OnSizeAllocated(width, height);
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            //heightConstraint = widthConstraint;
            HeightRequest = widthConstraint;
            this.Log($"{WidthRequest} {heightConstraint}");
            return base.OnMeasure(widthConstraint, heightConstraint);
        }
    }
}
