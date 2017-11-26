using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ZzaDesktop.Customers
{
    public class SimpleEditableCustomer :BindableBase
    {
        private Guid _id;
        public Guid Id {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _firstName;
        public string FirstName {
            get => _firstName;
            set => SetProperty(ref _firstName,value);
        }

        private string _lastName;
        public string LastName {
            get => _lastName;
            set => SetProperty(ref _lastName,value);
        }

        private string _email;
        public string Email {
            get => _email;
            set => SetProperty(ref _email,value);
        }

        private string _phone;
        public string Phone {
            get => _phone;
            set => SetProperty(ref _phone,value);
        }

    }
}
