using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class Payment : IComparable
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int IdPayment { get; set; }
        public decimal Summ { get; set; }
        public DateTime DatePayment { get; set; }
        public int IdPaymentFormat { get; set; }

        public virtual PaymentFormat IdPaymentFormatNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is Payment)
            {
                var cp = (Payment) obj;
                return DatePayment.CompareTo(cp.DatePayment);
            }
            else
            {
                return -1;
            }
        }

    }
}
