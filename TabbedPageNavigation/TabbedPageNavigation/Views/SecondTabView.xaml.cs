﻿using TabbedPageNavigation.Extensions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondTabView : ContentPage
    {
        public SecondTabView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}