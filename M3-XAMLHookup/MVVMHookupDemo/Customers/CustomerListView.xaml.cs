using System.Windows.Controls;

namespace MVVMHookupDemo.Customers
{
    /// <inheritdoc cref="" />
    /// <summary>
    /// Logique d'interaction pour CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : UserControl
    {
        public CustomerListView()
        {
            /*Second way of statically hooking up the MVVM equation,
             * instead of from the view (XAML)*/

            //this.DataContext = new CustomerListViewModel(); //Commented out for *Demo2 MVLocator*
            InitializeComponent();
        }
    }
}
