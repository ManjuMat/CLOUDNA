using CLOUDNA.Entities;
using System.IO;

namespace CLOUDNA.Entities
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HouseName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}

