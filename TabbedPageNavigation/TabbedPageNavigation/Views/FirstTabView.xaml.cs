﻿using TabbedPageNavigation.Extensions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedPageNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstTabView : ContentPage
    {
        public FirstTabView()
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