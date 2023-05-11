namespace Desktop.Models
{
    public partial class OrderStatus
    {
        public int IdOrderStatus { get; set; }
        public int IdOrders { get; set; }
        public int IdTypeOrderStatus { get; set; }

        public virtual Order IdOrdersNavigation { get; set; }
        public virtual TypeOrderStatus IdTypeOrderStatusNavigation { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj is OrderStatus)
            {
                var cp = (OrderStatus) obj;
                return IdOrderStatus.CompareTo(cp.IdOrderStatus);
            }
            else
            {
                return -1;
            }
        }
    }
}
