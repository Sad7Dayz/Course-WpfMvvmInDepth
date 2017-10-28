using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMHookupDemo
{
    //* Demo2 MVLocator*
    public static class ViewModelLocator
    {
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel",
                typeof(bool),
                typeof(ViewModelLocator),
                new PropertyMetadata(false,AutoWireViewModelChanged));

        public static bool GetAutoWireViewModel(DependencyObject obj) {
            return (bool) obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value) {
            obj.SetValue(AutoWireViewModelProperty, value);
        }

        /* This way of finding the viewModel in relation with the View name, will work as long
         as both the View and the ViewModel are in the same namespace.
         Otherwise will need to adapt the code...*/
        private static void AutoWireViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(DesignerProperties.GetIsInDesignMode(d)) return;
            var viewType = d.GetType();
            var viewTypeName = viewType.FullName;

            var viewModelTypeName = viewTypeName + "Model";
            var viewModelType = Type.GetType(viewModelTypeName);

            var viewModel = Activator.CreateInstance(viewModelType);

            ((FrameworkElement) d).DataContext = viewModel;
        }
    }
}
