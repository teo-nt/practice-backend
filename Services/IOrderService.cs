using MovieAPI.DTO;

namespace MovieAPI.Services
{
    public interface IOrderService
    {
        Task<OrderReadOnlyDTO> SubmitOrder(OrderSubmitDTO orderDto);
        Task<List<OrderReadOnlyDTO>> GetUserOrders(int userId);
    }
}
