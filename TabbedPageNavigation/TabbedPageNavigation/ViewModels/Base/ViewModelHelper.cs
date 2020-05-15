﻿using System;
using System.Globalization;
using System.Reflection;

using TabbedPageNavigation.Services.DependencyResolver;

using Xamarin.Forms;

namespace TabbedPageNavigation.ViewModels.Base
{
    public static class ViewModelHelper
    {
        public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached(
            propertyName: "AutoWireViewModel", 
            returnType: typeof(bool), 
            declaringType: typeof(ViewModelHelper), 
            defaultValue: default(bool), 
            propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = ComponentFactory.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}