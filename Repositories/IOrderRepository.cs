using MovieAPI.Models;

namespace MovieAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllUserOrders(int UserId);
    }
}
