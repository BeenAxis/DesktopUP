using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class Product : IComparable
    {
        public Product()
        {
            Ingredients = new HashSet<Ingredient>();
            ProductOrders = new HashSet<ProductOrder>();
            Reviews = new HashSet<Review>();
        }

        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int? IdStocks { get; set; }
        public int IdCategories { get; set; }

        public virtual Category IdCategoriesNavigation { get; set; }
        public virtual Stock IdStocksNavigation { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        
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
