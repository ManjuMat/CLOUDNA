using CLOUDNA.Entities;

namespace CLOUDNA.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime DeliveryExpectedDate { get; set; }
        public bool ContainsGift { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}


