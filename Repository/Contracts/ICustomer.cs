using CLOUDNA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CLOUDNA.Repository.Contracts
{
    public interface ICustomer
    {
        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<CustomerLatestOrder> GetDeliveryDetailsOfRecentOrder(string userEmail,string customerId);

        public Task<Customer> GetCustomer(string customerId, string email);
    }
}
