using System;
using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        private readonly ILogger<GiftController> _logger;

        public GiftController(IGiftService giftService , ILogger<GiftController> logger)
        {
             _giftService = giftService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _giftService.GetAllGiftsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all gifts");
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var gift = await _giftService.GetGiftByIdAsync(id);
                return gift == null ? NotFound() : Ok(gift);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving gift by ID: {Id}", id);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GiftName/{GiftName}")]
        public async Task<IActionResult> GetByGiftName(string GiftName)
        {
            try
            {
                var gift = await _giftService.GetByNameGiftAsync(GiftName);
                return gift == null ? NotFound() : Ok(gift);
            }
            catch (Exception ex)

            {
                _logger.LogError(ex, "Error retrieving gift by Name: {GiftName}", GiftName);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("DonorName/{DonorName}")]
        public async Task<IActionResult> GetByDonorName(string DonorName)
        {
            try
            {
                var gift = await _giftService.GetByNameDonorAsync(DonorName);
                return gift == null ? NotFound() : Ok(gift);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving gift by Donor Name: {DonorName}", DonorName);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("CountBuyers/{CountBuyers}")]
        public async Task<IActionResult> GetByCountBuyers(int CountBuyers)
        {
            try
            {
                var gifts = await _giftService.GetByNumOfBuyersAsync(CountBuyers);
                return Ok(gifts); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving gifts by Count Buyers: {CountBuyers}", CountBuyers);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("SortByAmountPepole")]
        public async Task<IActionResult> SortByAmountPepole()
        {
            try
            {
                var gifts = await _giftService.SortByAmountPepole();
                return Ok(gifts);
            }
            catch (Exception ex)
            {    _logger.LogInformation("Sorting gifts by amount of people");
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("SortByPrice")]
        public async Task<IActionResult> SortByPrice()
        {
            try
            {
                var gifts = await _giftService.SortByPrice();
                return Ok(gifts);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Sorting gifts by price");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Post([FromBody] GiftDTO dto)
        {
            try
            {
                var newGift = await _giftService.CreateGiftAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = newGift.IdGift }, newGift);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new gift");
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _giftService.DeleteGiftAsync(id);
                return success ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting gift with ID {Id}", id);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("{id}/draw")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> DrawWinner(int id)
        {
            try
            {
             var result = await _giftService.DrawWinnerForGiftAsync(id);

                if (result == null)
                {
                    return BadRequest("לא ניתן לבצע הגרלה: המתנה לא נמצאה, כבר הוגרלה או שאין רוכשים.");
                }

                return Ok(new { Message = "ההגרלה בוצעה בהצלחה!", WinnerUserId = result.UserId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error drawing winner for gift with ID {Id}", id);
                throw new Exception("Error drawing winner for gift", ex);
            }
           
        }
    } 
}
