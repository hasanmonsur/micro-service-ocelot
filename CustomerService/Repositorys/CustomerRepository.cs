using CustomerService.Contacts;
using CustomerService.Data;
using CustomerService.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CustomerService.Repositorys
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _dapperContext;

        public CustomerRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "SELECT * FROM Customers";
                return await connection.QueryAsync<Customer>(sql);
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "SELECT * FROM Customers WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
            }
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "INSERT INTO Customers (CustomerName, CustomerAddress) VALUES (@CustomerName, @CustomerAddress)";
                return await connection.ExecuteAsync(sql, customer);
            }
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "UPDATE Customers SET CustomerName = @CustomerName, CustomerAddress = @CustomerAddress WHERE Id = @Id";
                return await connection.ExecuteAsync(sql, customer);
            }
        }

        public async Task<int> DeleteCustomer(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "DELETE FROM Customers WHERE Id = @Id";
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
