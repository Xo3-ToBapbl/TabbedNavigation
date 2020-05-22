using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TabbedPageNavigation.Controls
{
    public class SquareGrid : Grid
    {
        protected override void OnSizeAllocated(double width, double height)
        {
            HeightRequest = width;

            base.OnSizeAllocated(width, width);
        }
    }
}
