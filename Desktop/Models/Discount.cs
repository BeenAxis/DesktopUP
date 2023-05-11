using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class Discount : IComparable
    {
        public Discount()
        {
            Stocks = new HashSet<Stock>();
        }

        public int IdDiscount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount1 { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is Discount)
            {
                var cp = (Discount) obj;
                return String.Compare(Name, cp.Name, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
