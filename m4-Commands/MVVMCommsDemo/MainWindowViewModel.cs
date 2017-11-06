using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using MVVMCommsDemo.Customers;

namespace MVVMCommsDemo
{
    public class MainWindowViewModel :INotifyPropertyChanged
    {
        private string _notificationMessage;
        private Timer _timer = new Timer(5000);

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public object CurrentViewModel { get; set; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new CustomerListViewModel();
            _timer.Elapsed += (s, e) =>
                NotificationMessage = "At the tone the time will be: " + DateTime.Now.ToLocalTime();
            _timer.Start();
        }

        public string NotificationMessage {
            get => _notificationMessage;
            set {
                if (value == _notificationMessage) return;
                _notificationMessage = value;
                PropertyChanged(this,new PropertyChangedEventArgs("NotificationMessage"));
            }
        }
    }
}
