using System.Collections.ObjectModel;
using System.ComponentModel;
using MVVMHookupDemo.Services;
using Zza.Data;

namespace MVVMHookupDemo.Customers
{
    public class CustomerListViewModel
    {
        private ICustomersRepository _repository = new CustomersRepository();
        private ObservableCollection<Customer> _customers;

        public CustomerListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            Customers = new ObservableCollection<Customer>( _repository.GetCustomersAsync().Result);
        }

        public ObservableCollection<Customer> Customers {
            get {
                return _customers;
            }
            set {
                _customers = value;
            }
        }
    }
}
