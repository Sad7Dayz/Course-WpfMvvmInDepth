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
        private Customer _editingCustomer;

        public bool EditMode {
            get => _editMode;
            set => SetProperty(ref _editMode,value);
        }

        public void SetCustomer(Customer cust) {
            _editingCustomer = cust;
        }

    }
}
