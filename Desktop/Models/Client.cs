using System;
using System.Collections.Generic;

namespace Desktop.Models
{
    public partial class Client : IComparable
    {
        public Client()
        {
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }

        public int IdClient { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string ThirdName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Deleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        
        
        public int CompareTo(object obj)
        {
            if (obj is Client)
            {
                var cp = (Client) obj;
                return String.Compare(FirstName, cp.FirstName, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
