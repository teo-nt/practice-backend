using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.DTO;
using MovieAPI.Services;
using System.Security.Claims;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public OrderController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderReadOnlyDTO>> SubmitOrder(OrderSubmitDTO orderSubmitDTO)
        {
            var order = await _applicationService.OrderService.SubmitOrder(orderSubmitDTO);
            return Ok(order);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<OrderReadOnlyDTO>>> GetUserOrders()
        {
            var userClaimsId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ = int.TryParse(userClaimsId, out int userId);
            var orders = await _applicationService.OrderService.GetUserOrders(userId);
            return Ok(orders);
        }
    }
}
