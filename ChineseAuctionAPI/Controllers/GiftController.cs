using ChineseAuctionAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")] 
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService) => _giftService = giftService;

        [HttpGet]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> Get() => Ok(await _giftService.GetAllGiftsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var gift = await _giftService.GetGiftByIdAsync(id);
            return gift == null ? NotFound() : Ok(gift);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> Post([FromBody] GiftDTO dto)
        {
            var newGift = await _giftService.CreateGiftAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = newGift.IdGift }, newGift);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _giftService.DeleteGiftAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
