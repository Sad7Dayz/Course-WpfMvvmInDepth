using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using Zza.Data;
using ZzaDesktop.Customers;
using ZzaDesktop.OrderPrep;
using ZzaDesktop.Orders;

namespace ZzaDesktop
{
    public class MainWindowViewModel :BindableBase
    {
        private CustomerListViewModel _customerListViewModel = new CustomerListViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();
        private AddEditCustomerViewModel _addEditViewModel = new AddEditCustomerViewModel();
        
        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel,value);}
        }

        public RelayCommand<string> NavCommand { get; private set; }

        public MainWindowViewModel() {
            NavCommand = new RelayCommand<string>(OnNav);
            _customerListViewModel.PlaceOrderRequested += NavToOrder;
            _customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            _customerListViewModel.EditCustomerRequested += NavToEditCustomer;
        }

        private void NavToEditCustomer(Customer cust) {
            _addEditViewModel.EditMode = false;
            _addEditViewModel.SetCustomer(cust);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToAddCustomer(Customer cust) {
            _addEditViewModel.EditMode = true;
            _addEditViewModel.SetCustomer(cust);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToOrder(Guid customerId) {
            _orderViewModel.CustomerId = customerId;
            CurrentViewModel = _orderViewModel;
        }

        private void OnNav(string destination) {
            switch (destination) {
                case "orderPrep":
                    CurrentViewModel = _orderPrepViewModel;
                    break;
                default:
                    CurrentViewModel = _customerListViewModel;
                    break;
            }
        }
    }
}
