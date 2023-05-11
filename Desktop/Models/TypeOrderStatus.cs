using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class TypeOrderStatus : IComparable
    {
        public TypeOrderStatus()
        {
            HistoryOrders = new HashSet<HistoryOrder>();
            OrderStatuses = new HashSet<OrderStatus>();
        }

        public int IdTypeOrderStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HistoryOrder> HistoryOrders { get; set; }
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is TypeOrderStatus)
            {
                var cp = (TypeOrderStatus) obj;
                return String.Compare(Name, cp.Name, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
