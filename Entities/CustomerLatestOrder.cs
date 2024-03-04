namespace CLOUDNA.Entities
{
    public class CustomerLatestOrder
    {
        public Customer Customer { get; set; }
        //public List<Order> Orders { get; set; } = new List<Order>();
        public Order Order { get; set; }
    }
}
