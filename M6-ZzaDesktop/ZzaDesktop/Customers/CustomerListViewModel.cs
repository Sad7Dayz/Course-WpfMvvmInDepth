using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Customers
{
    public class CustomerListViewModel :BindableBase
    {
        private ICustomersRepository _repo ;
        private List<Customer> _allCustomers;
        private ObservableCollection<Customer> _customers;
        private string _searchInput;

        public CustomerListViewModel(ICustomersRepository repo) {
            _repo = repo;
            PlaceOrderCommand = new RelayCommand<Customer>(OnPlaceOrder);
            AddCustomerCommand = new RelayCommand(OnAddCustomer);
            EditCustomerCommand = new RelayCommand<Customer>(OnEditCustomer);
            ClearSearchCommand = new RelayCommand(OnClearSearch);

        }


        public event Action<Guid> PlaceOrderRequested = delegate { };
        public event Action<Customer> AddCustomerRequested = delegate { };
        public event Action<Customer> EditCustomerRequested = delegate { };

        public ObservableCollection<Customer> Customers {
            get => _customers;
            set => SetProperty(ref _customers,value);
        }
        public string SearchInput {
            get => _searchInput;
            set {
                SetProperty(ref _searchInput, value);
                FilterCustomers(_searchInput);
            }
        }
        public RelayCommand<Customer> PlaceOrderCommand { get; }
        public RelayCommand AddCustomerCommand { get; }
        public RelayCommand<Customer> EditCustomerCommand { get; }
        public RelayCommand ClearSearchCommand { get;}


        /// <summary>Triggered by the 'Loaded' event of the <see cref="CustomerListView"/>.
        /// It then populates the view the list of customers.</summary>
        public async void LoadCustomers() {
            _allCustomers = await _repo.GetCustomersAsync();
            Customers = new ObservableCollection<Customer>(_allCustomers);
        }

        private void FilterCustomers(string searchInput) {
            Customers = string.IsNullOrWhiteSpace(searchInput)
                ? new ObservableCollection<Customer>(_allCustomers)
                : new ObservableCollection<Customer>(_allCustomers
                    .Where(c => c.FullName.ToLower()
                        .Contains(searchInput.ToLower())));
        }

        private void OnEditCustomer(Customer cust) {
            EditCustomerRequested(cust);    
        }

        private void OnAddCustomer() {
            AddCustomerRequested(new Customer{Id = Guid.NewGuid()});
        }

        private void OnPlaceOrder(Customer customer) {
            PlaceOrderRequested(customer.Id);
        }

        private void OnClearSearch() {
            SearchInput = null;
        }
    }
}

  