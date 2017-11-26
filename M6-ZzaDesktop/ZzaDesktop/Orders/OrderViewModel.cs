using System;

namespace ZzaDesktop.Orders
{
    class OrderViewModel:BindableBase 
    {
        private Guid _customerId;

        /// <summary></summary>
        public Guid CustomerId {
            get { return _customerId; }
            set { SetProperty(ref _customerId, value); }
        }

    }
}
 