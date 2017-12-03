using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ZzaDesktop
{
    public class ValidatatableBindableBase : BindableBase, INotifyDataErrorInfo
    {


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Count > 0;

        public IEnumerable GetErrors(string propertyName) {
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        protected override void SetProperty<T>(ref T member, T val,[CallerMemberName] string porpertyName = null) {
            base.SetProperty(ref member, val, porpertyName);
            ValidateProperty(porpertyName, val);
        }

        private void ValidateProperty<T>(string porpertyName, T value) {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this) {MemberName = porpertyName};
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
                _errors[porpertyName] = results.Select(c => c.ErrorMessage).ToList();
            else
                _errors.Remove(porpertyName);

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(porpertyName));
        }
    }
}
