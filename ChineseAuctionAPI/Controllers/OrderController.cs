using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Services.Intarfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;


        public OrderController(IOrderService IOrderService ,ILogger<OrderController> logger)
        {
            _orderService = IOrderService;
            _logger = logger;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllByUser(int userId)
        {
            try
            {
                var orders = await _orderService.GetAllAsync(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error get orders for userId" , userId);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByIdWithGiftsAsync/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllAsynceByUserId(int userId)
        {
            try
            {
                var orders = await _orderService.GetDraftOrderByUserAsync(userId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
               
                _logger.LogError(ex, "Error fetching orders for user ID: {UserId}", userId);
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDTO>> GetById(int orderId)
        {
            try
            {
                var order = await _orderService.GetByIdWithGiftsAsync(orderId);
                if (order == null) return NotFound($"הזמנה מספר {orderId} לא נמצאה.");
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error get order for orderId {orderId}", orderId);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("add-gift")]
        public async Task<IActionResult> AddOrUpdateGift([FromBody] AddGiftRequest request)
        {
            try
            {
                var result = await _orderService.AddOrUpdateGiftInOrderAsync(request.userId, request.GiftId, request.Amount);
                if (result) return Ok("הסל עודכן בהצלחה.");
                return BadRequest("שגיאה בעדכון הסל.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error add gift to the cart");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("remove-gift")]
        public async Task<IActionResult> RemoveGift(int orderId, int giftId, int amount)
        {
            try
            {
                var result = await _orderService.DeleteAsync(orderId, giftId, amount);
                if (result) return Ok("הפריט הוסר מהסל.");
                return BadRequest("לא ניתן היה להסיר את הפריט (ודא שהכמות נכונה).");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error renove for gift giftId {giftId}", giftId);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("complete/{orderId}")]
        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            try
            {
                var result = await _orderService.CompleteOrder(orderId);
                if (result) return Ok("ההזמנה בוצעה בהצלחה!");
                return BadRequest("לא ניתן היה להשלים את ההזמנה.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error complitie order  {orderId}", orderId);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
