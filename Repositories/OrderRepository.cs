using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;

namespace MovieAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _dataContext.Orders.AddAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllUserOrders(int UserId)
        {
            return await _dataContext.Orders.Where(o => o.UserId == UserId)
                .Include(o => o.OrderMovies).ThenInclude(om => om.Movie)
                .OrderByDescending(order => order.OrderDate)
                .ToListAsync();
        }
    }
}
