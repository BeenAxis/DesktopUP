using System;

namespace Desktop.Models
{
    public partial class HistoryOrder : IComparable
    {
        public int IdHistoryOrders { get; set; }
        public DateTime DateWrite { get; set; }
        public int IdOrders { get; set; }
        public int IdTypeOrderStatus { get; set; }

        public virtual Order IdOrdersNavigation { get; set; }
        public virtual TypeOrderStatus IdTypeOrderStatusNavigation { get; set; }
        public int CompareTo(object obj)
        {
            if (obj is HistoryOrder)
            {
                var cp = (HistoryOrder) obj;
                return DateWrite.CompareTo(cp.DateWrite);
            }
            else
            {
                return -1;
            }
        }
    }
}
