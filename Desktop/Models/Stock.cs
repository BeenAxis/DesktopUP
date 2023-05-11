using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class Stock : IComparable
    {
        public Stock()
        {
            Products = new HashSet<Product>();
        }

        public int IdStocks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUntil { get; set; }
        public int IdDiscount { get; set; }

        public virtual Discount IdDiscountNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is Stock)
            {
                var cp = (Stock) obj;
                return String.Compare(Name, cp.Name, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
