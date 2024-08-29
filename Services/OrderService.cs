using MovieAPI.DTO;
using MovieAPI.Models;
using MovieAPI.Repositories;

namespace MovieAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderReadOnlyDTO>> GetUserOrders(int userId)
        {
            var orders = await _unitOfWork.OrderRepository.GetAllUserOrders(userId);
            List<OrderReadOnlyDTO> ordersToReturn = [];

            foreach (var order in orders)
            {
                List<MovieOrderDTO> movies = [];
                foreach (var movie in order.OrderMovies)
                {
                    movies.Add(new MovieOrderDTO()
                    {
                        Id = movie.MovieId,
                        Title = movie.Movie.Title,
                        Url = movie.Movie.Url,
                        Price = movie.Movie.Price,
                        Quantity = movie.Quantity
                    });
                }

                ordersToReturn.Add(new OrderReadOnlyDTO
                {
                    OrderId = order.Id,
                    Movies = movies,
                    OrderDate = order.OrderDate
                });
            }

            //ordersToReturn.Sort();
            
            return ordersToReturn;
        }

        public async Task<OrderReadOnlyDTO> SubmitOrder(OrderSubmitDTO orderDto)
        {
            List<OrderMovie> orderMovies = [];
            foreach (var orderMovie in orderDto.MoviesToOrder)
            {
                orderMovies.Add(new OrderMovie()
                {
                    MovieId = orderMovie.Id,
                    Quantity = orderMovie.Quantity,
                });
            }

            Order order = new Order
            {
                UserId = orderDto.UserId,
                OrderMovies = orderMovies,
                OrderDate = DateTime.Now,
            };

            var orderSubmitted = await _unitOfWork.OrderRepository.AddOrder(order);

            await _unitOfWork.SaveAsync();

            List<MovieOrderDTO> movies = [];
            foreach (var movie in orderDto.MoviesToOrder)
            {
                movies.Add(new MovieOrderDTO()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Url = movie.Url,
                    Price = movie.Price,
                    Quantity = movie.Quantity
                });
            }

            OrderReadOnlyDTO orderToReturn = new()
            {
                OrderId = orderSubmitted.Id,
                Movies = movies,
                OrderDate = orderSubmitted.OrderDate
            };

            return orderToReturn;
        }
    }
}
