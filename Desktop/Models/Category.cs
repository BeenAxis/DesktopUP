using System;
using System.Collections.Generic;
using System.Runtime;

namespace Desktop.Models
{
    public partial class Category : IComparable
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategories { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public int CompareTo(object obj)
        {
            if (obj is Product)
            {
                var cp = (Product) obj;
                return String.Compare(Name, cp.Name, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
