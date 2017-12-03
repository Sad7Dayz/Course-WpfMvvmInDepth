using System;
using Zza.Data;
using ZzaDesktop.Customers;
using ZzaDesktop.OrderPrep;
using ZzaDesktop.Orders;
using ZzaDesktop.Services; 
using Microsoft.Practices.Unity;
using Unity;

namespace ZzaDesktop
{
    public class MainWindowViewModel :BindableBase
    {
        private readonly OrderViewModel _orderViewModel = new OrderViewModel();
        private readonly OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();

        private readonly AddEditCustomerViewModel _addEditViewModel;
        private readonly CustomerListViewModel _customerListViewModel;
        
        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel,value);}
        }

        public RelayCommand<string> NavCommand { get; private set; }

        public MainWindowViewModel() {
            NavCommand = new RelayCommand<string>(OnNav);

            //_addEditViewModel = new AddEditCustomerViewModel(_repo);
            //_customerListViewModel = new CustomerListViewModel(_repo);

            _addEditViewModel = ContainerHelper.Container.Resolve<AddEditCustomerViewModel>();
            _customerListViewModel = ContainerHelper.Container.Resolve<CustomerListViewModel>();

            _customerListViewModel.PlaceOrderRequested += NavToOrder;
            _customerListViewModel.AddCustomerRequested += NavToAddCustomer;
            _customerListViewModel.EditCustomerRequested += NavToEditCustomer;
            _addEditViewModel.Done += NavToCustomerList;
        }

        private void NavToCustomerList() {
            CurrentViewModel = _customerListViewModel;
        }

        private void NavToEditCustomer(Customer cust) {
            _addEditViewModel.EditMode = true;
            _addEditViewModel.SetCustomer(cust);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToAddCustomer(Customer cust) {
            _addEditViewModel.EditMode = false;
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
