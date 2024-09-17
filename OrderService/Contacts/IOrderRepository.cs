using OrderService.Models;

namespace OrderService.Contacts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<int> AddOrder(Order product);
        Task<int> UpdateOrder(Order product);
        Task<int> DeleteOrder(int id);
    }

}
