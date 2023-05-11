using System;

namespace Desktop.Models
{
    public partial class Review : IComparable
    {
        public int IdReviews { get; set; }
        public string Text { get; set; }
        public int IdProduct { get; set; }
        public int IdClient { get; set; }

        public int Deleted { get; set; }
        
        public virtual Client IdClientNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is Review)
            {
                var cp = (Review) obj;
                return String.Compare(Text, cp.Text, StringComparison.Ordinal);
            }
            else
            {
                return -1;
            }
        }
    }
}
