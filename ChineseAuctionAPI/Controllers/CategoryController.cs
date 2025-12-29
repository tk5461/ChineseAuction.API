using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Services.Intarfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger; 

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiftCategory>>> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת כל הקטגוריות");
                return StatusCode(500, "אירעה שגיאה פנימית בשרת בעת שליפת הנתונים.");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GiftCategory>> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בשליפת קטגוריה מזהה: {Id}", id);
                return StatusCode(500, "אירעה שגיאה פנימית בשרת.");
            }
        }


        [HttpPost]
        public async Task<ActionResult<GiftCategory>> Create([FromBody] CategoryDTO categoryDto)
        {
            try
            {
                if (categoryDto == null) return BadRequest("Invalid data.");

                var newCategory = await _categoryService.AddAsync(categoryDto);
                return CreatedAtAction(nameof(GetById), new { id = newCategory.Id }, newCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה ביצירת קטגוריה חדשה");
                return StatusCode(500, "אירעה שגיאה בעת שמירת הקטגוריה.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiftCategory category)
        {
            try
            {
                var success = await _categoryService.UpdateAsync(id, category);
                if (!success)
                {
                    return NotFound($"Update failed. Category {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה בעדכון קטגוריה מזהה: {Id}", id);
                return StatusCode(500, "אירעה שגיאה בעת עדכון הקטגוריה.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _categoryService.DeleteAsync(id);
                if (!success)
                {
                    return NotFound($"Delete failed. Category {id} not found.");
                }
                return Ok(new { message = "Category deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה במחיקת קטגוריה מזהה: {Id}", id);
                return StatusCode(500, "אירעה שגיאה בעת מחיקת הקטגוריה.");
            }
        }
    }
}