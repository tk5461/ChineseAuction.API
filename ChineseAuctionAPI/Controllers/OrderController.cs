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

        public OrderController(IOrderService IOrderService)
        {
            _orderService = IOrderService;
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
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("draft/{userId}")]
        public async Task<ActionResult<OrderDTO>> GetDraftOrder(int userId)
        {
            try
            {
                var draft = await _orderService.GetDraftOrderByUserAsync(userId);
                if (draft == null) return NotFound("לא נמצא סל קניות פעיל למשתמש זה.");
                return Ok(draft);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("add-gift")]
        public async Task<IActionResult> AddOrUpdateGift([FromBody] AddGiftRequest request)
        {
            try
            {
                var result = await _orderService.AddOrUpdateGiftInOrderAsync(request.OrderId, request.GiftId, request.Amount);
                if (result) return Ok("הסל עודכן בהצלחה.");
                return BadRequest("שגיאה בעדכון הסל.");
            }
            catch (Exception ex)
            {
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
                return StatusCode(500, ex.Message);
            }
        }
    }
}
