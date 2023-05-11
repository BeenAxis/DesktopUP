using System;

namespace Desktop.Models
{
    public partial class Sending : IComparable
    {
        public int IdSending { get; set; }
        public DateTime DateSending { get; set; }
        public decimal Cost { get; set; }
        public string SendingType { get; set; }
        public string Address { get; set; }
        public int IdOrders { get; set; }

        public virtual Order IdOrdersNavigation { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is Sending)
            {
                var cp = (Sending) obj;
                return DateSending.CompareTo(cp.DateSending);
            }
            else
            {
                return -1;
            }
        }
    }
}
