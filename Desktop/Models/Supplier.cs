using System;

namespace Desktop.Models
{
    public partial class Supplier : IComparable
    {
        public int IdSuppliers { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int IdIngredients { get; set; }

        public virtual Ingredient IdIngredientsNavigation { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is Supplier)
            {
                var cp = (Supplier) obj;
                return String.Compare(Name, cp.Name, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
