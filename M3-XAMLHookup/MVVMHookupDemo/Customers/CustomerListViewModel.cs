using System.Collections.ObjectModel;
using System.ComponentModel;
using MVVMHookupDemo.Services;
using Zza.Data;

namespace MVVMHookupDemo.Customers
{
    public class CustomerListViewModel
    {
        private ICustomersRepository _customersRepository = new CustomersRepository();
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerListViewModel() {


            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject())) return; 
                /*cannot use async and await keywords in a constructor.
             * The 'Result' property on a task makes the method execute synchronously.
             * And, we wrap it 'cause we need an Observable collection.            */
                Customers = new ObservableCollection<Customer>(_customersRepository.GetCustomersAsync().Result);
        }
    }
}
