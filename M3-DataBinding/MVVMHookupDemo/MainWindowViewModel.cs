using MVVMHookupDemo.Customers;

namespace MVVMHookupDemo
{
    //Demo5- Implicit DataTemplate for "ViewModel First MVVM  hookup (in the  Main View associated files.)
    public class MainWindowViewModel
    {
        public MainWindowViewModel() {
            CurrentViewModel = new CustomerListViewModel();
        }

        public object CurrentViewModel { get; set; }
    }
}
