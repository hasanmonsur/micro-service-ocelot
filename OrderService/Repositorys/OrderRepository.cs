using Dapper;
using OrderService.Contacts;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _dapperContext;

        public OrderRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "SELECT * FROM Orders";
                return await connection.QueryAsync<Order>(sql);
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "SELECT * FROM Orders WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<Order>(sql, new { Id = id });
            }
        }

        public async Task<int> AddOrder(Order order)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "INSERT INTO Orders (CustomerName, TotalAmount,OrderDate) VALUES (@CustomerName, @TotalAmount,@OrderDate)";
                return await connection.ExecuteAsync(sql, order);
            }
        }

        public async Task<int> UpdateOrder(Order order)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "UPDATE Orders SET CustomerName = @CustomerName, TotalAmount = @TotalAmount WHERE Id = @Id";
                return await connection.ExecuteAsync(sql, order);
            }
        }

        public async Task<int> DeleteOrder(int id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                string sql = "DELETE FROM Orders WHERE Id = @Id";
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
