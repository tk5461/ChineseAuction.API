using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Services.Intarfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Manager")]

    public class DonorController : ControllerBase
    {
        private readonly IDonorService _service;
        private readonly ILogger<DonorController> _logger;

        public DonorController(IDonorService service, ILogger<DonorController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAllDonorsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error retrieving all donors");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var donor = await _service.GetDonorByIdAsync(id);
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error retrieving donor with ID {Id}", id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(DonorDTO dto)
        {
            try
            {
                var donor = await _service.CreateAsync(dto);
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error creating new donor");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DonorDTO dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error updating donor with ID {Id}", id);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var donor = await _service.DeleteAsync(id);
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error deleting donor with ID {Id}", id);
            }
        }
        [HttpGet("GetGiftByIdDoonor")]
        public async Task<IActionResult> GetGiftByIdDoonor(int IdDonor)
        {
            try
            {
                var gifts = await _service.GetGiftsasync(IdDonor);
                return Ok(gifts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error retrieving gifts for donor with ID {IdDonor}", IdDonor);
            }
        }

        [HttpGet("GetDonorByGiftAsync/{gift}")]
        public async Task<IActionResult> GetDonorByGiftAsync(string gift)
        {
            try
            {
                var donor = await _service.GetDonorByGiftAsync(gift);
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error retrieving donor for gift {Gift}", gift);
            }
        }

        [HttpGet("GetDonorByNameAsync/{name}")]
        public async Task<IActionResult> GetDonorByNameAsync(string name)
        {
            try
            {
                var donor = await _service.GetDonorByNameAsync(name);
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error retrieving donor with name {Name}", name);
            }
        }
        [HttpGet("GetDonorByEmailAsync/{Email}")]
        public async Task<IActionResult> GetDonorByEmailAsync(string Email)
        {
            try
            {
                var donor = await _service.GetDonorByEmailAsync(Email);
                return Ok(donor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex, "Error retrieving donor with email {Email}", Email);
            }
        }
    }
}