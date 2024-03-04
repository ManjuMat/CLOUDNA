using CLOUDNA.Context;
using CLOUDNA.Entities;
using CLOUDNA.Repository.Contracts;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CLOUDNA.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomer(string customerId, string email)
        {
            var query = "SELECT * FROM Customers WHERE CustomerId = @customerId AND Email= @email ";
            using (var connection = _context.CreateConnection())
            {
                var customer = await connection.QuerySingleOrDefaultAsync<Customer>(query, new { customerId, email });
                return customer;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var query = "SELECT * FROM Customers";
            using (var connection = _context.CreateConnection())
            {
                var customers = await connection.QueryAsync<Customer>(query);
                return customers.ToList();
            }
        }

        public async Task<CustomerLatestOrder> GetDeliveryDetailsOfRecentOrder(string userEmail, string customerId)
        {
            var procedureName = "GetMostRecentOrder";
            var parameters = new DynamicParameters();
            parameters.Add("Email", userEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", customerId, DbType.String, ParameterDirection.Input);
            using (var connection = _context.CreateConnection())
            {
                var latestOrder = await connection.QueryFirstOrDefaultAsync<CustomerLatestOrder>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return latestOrder;
            }
        }
    }
}
