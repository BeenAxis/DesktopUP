using System;

namespace Desktop.Models
{
    public partial class ProductOrder : IComparable
    {
        public int IdProductOrders { get; set; }
        public decimal CostOneItem { get; set; }
        public int IdProduct { get; set; }
        public int IdOrders { get; set; }

        public virtual Order IdOrdersNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is ProductOrder)
            {
                var cp = (ProductOrder) obj;
                return CostOneItem.CompareTo(cp.CostOneItem);
            }
            else
            {
                return -1;
            }
        }
    }
}
