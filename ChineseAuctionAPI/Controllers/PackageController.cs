using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Services;
using ChineseAuctionAPI.Services.Intarfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{  
    [ApiController]
     [Route("api/[controller]")]
    public class PackageController : Controller
    {

      
        private readonly IPackageService _service;
        private readonly ILogger<PackageController> _logger;

        public PackageController(IPackageService service , ILogger<PackageController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetAll()
        {
            try
            {
                var packages = await _service.GetAllPackagesAsync();
                return Ok(packages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get all packages");
                throw new Exception("Error occurred while retrieving packages.",ex);
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageDTO>> GetById(int id)
        {
            try
            {
                var package = await _service.GetPackageByIdAsync(id);
                if (package == null)
                {
                    return NotFound(new { Message = $"Package with ID {id} not found." });
                }
                return Ok(package);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error get packge by id ID {Id}", id);
                throw new Exception("Error occurred while retrieving package by id.");
            }
           
        }
        [HttpPost]
        [Authorize(Roles = "Manager")]

        public async Task<ActionResult> Create([FromBody] PackageDTO packageDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                // עכשיו זה יעבוד כי המתודה מחזירה Package ולא void
                var newPackage = await _service.CreatePackageAsync(packageDTO);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = newPackage.IdPackage },
                    newPackage
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new package");
                return StatusCode(500, "Error occurred while creating package.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> Update(int id, [FromBody] PackageDTO packageDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updated = await _service.UpdatePackageAsync(id, packageDto);
                if (!updated)
                {
                
                    return NotFound(new { Message = $"Update failed. Package with ID {id} not found." });
                }

                return NoContent(); // מחזירים 204 No Content בעדכון מוצלח
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Update Package {Id}", id);
                throw new Exception("Error occurred while update packages.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var deleted = await _service.DeletePackageAsync(id);
                if (!deleted)
                {
                    return NotFound(new { Message = $"Delete failed. Package with ID {id} not found." });
                }

                return Ok(new { Message = "Package deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Delete Package {Id}", id);
                throw new Exception("Error occurred while delete packages.");
            }
        }
    }
}
