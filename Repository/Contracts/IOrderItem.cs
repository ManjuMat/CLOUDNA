using CLOUDNA.Entities;

namespace CLOUDNA.Repository.Contracts
{
    public interface IOrderItem
    {
        public Task<IEnumerable<Customer>> GetCustomers();

    }
}
