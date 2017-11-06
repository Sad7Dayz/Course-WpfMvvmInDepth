using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMCommsDemo.Services;
using Zza.Data;

namespace MVVMCommsDemo.Customers
{
    public class CustomerListViewModel : INotifyPropertyChanged
    {
        private ICustomersRepository _repository = new CustomersRepository();
        private Customer _selectedCustomer;
        private ObservableCollection<Customer> _customers;

        //M4-Demo 'Commands for View to ViewModel communication'
        public RelayCommand DeleteCommand { get; }

        public ObservableCollection<Customer> Customers {
            get => _customers;
            set {
                if (_customers == value) return;
                _customers = value;
                PropertyChanged(this,new PropertyChangedEventArgs("Customers"));
            }
        }

        public Customer SelectedCustomer {
            get => _selectedCustomer;
            set {
                _selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
                PropertyChanged(this,new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public CustomerListViewModel() {
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }
         
        public async void LoadCustomers() {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;
             
            Customers = new ObservableCollection<Customer>(await _repository.GetCustomersAsync());
        }

        private bool CanDelete() {
            return SelectedCustomer != null;
        }
         
        private void OnDelete() {
            Customers.Remove(SelectedCustomer);

        }

    }
}
 