using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int IdIngredients { get; set; }
        public string Name { get; set; }
        public decimal Count { get; set; }
        public string MeasureType { get; set; }
        public int IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is Ingredient)
            {
                var cp = (Ingredient) obj;
                return Count.CompareTo(cp.Count);
            }
            else
            {
                return -1;
            }
        }
    }
}
