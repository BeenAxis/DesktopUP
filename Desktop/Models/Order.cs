using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class Order : IComparable
    {
        public Order()
        {
            HistoryOrders = new HashSet<HistoryOrder>();
            OrderStatuses = new HashSet<OrderStatus>();
            ProductOrders = new HashSet<ProductOrder>();
            Sendings = new HashSet<Sending>();
        }

        public int IdOrders { get; set; }
        public DateTime DateCreated { get; set; }
        public int IdClient { get; set; }
        public int? IdPayment { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Payment IdPaymentNavigation { get; set; }
        public virtual ICollection<HistoryOrder> HistoryOrders { get; set; }
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<Sending> Sendings { get; set; }
        
        
        public int CompareTo(object obj)
        {
            if (obj is Order)
            {
                var cp = (Order) obj;
                return DateCreated.CompareTo(cp.DateCreated);
            }
            else
            {
                return -1;
            }
        }

    }
}
