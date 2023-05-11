using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class PaymentFormat : IComparable
    {
        public PaymentFormat()
        {
            Payments = new HashSet<Payment>();
        }

        public int IdPaymentFormat { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is PaymentFormat)
            {
                var cp = (PaymentFormat) obj;
                return String.Compare(Name, cp.Name, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
