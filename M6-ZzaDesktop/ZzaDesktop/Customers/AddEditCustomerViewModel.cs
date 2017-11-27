using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Customers
{
    public class AddEditCustomerViewModel :BindableBase
    {
        private bool _editMode; 
        private SimpleEditableCustomer _customer;
        private Customer _editingCustomer;

        public AddEditCustomerViewModel() {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave,CanSave);
        }

        public event Action Done = delegate { };

        public bool EditMode {
            get => _editMode;
            set => SetProperty(ref _editMode, value);
        }
        public SimpleEditableCustomer Customer {
            get => _customer;
            set => SetProperty(ref _customer,value);
        }
        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }   

        public void SetCustomer(Customer cust) {
            _editingCustomer = cust;
            Customer = new SimpleEditableCustomer();
            CopyCustomer(cust, Customer);
        }

        private void CopyCustomer(Customer source, SimpleEditableCustomer target)  {
            target.Id = source.Id;
            if (!EditMode) return;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Phone = source.Phone;
            target.Email = source.Email;
        }

        private bool CanSave() {
            return true;
        }

        private void OnSave() {
            Done();
        }

        private void OnCancel() {
            Done();
        }
    }
}
