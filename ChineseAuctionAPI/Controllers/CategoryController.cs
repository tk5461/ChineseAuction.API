using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // 1. שליפת כל הקטגוריות
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiftCategory>>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // 2. שליפת קטגוריה לפי מזהה
        [HttpGet("{id}")]
        public async Task<ActionResult<GiftCategory>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(category);
        }

        // 3. יצירת קטגוריה חדשה - מקבל DTO (רק שם)
        [HttpPost]
        public async Task<ActionResult<GiftCategory>> Create([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null) return BadRequest();

            // ה-Service יהפוך את ה-DTO למודל ויוסיף ל-DB
            var newCategory = await _categoryService.AddAsync(categoryDto);

            return CreatedAtAction(nameof(GetById), new { id = newCategory.Id }, newCategory);
        }

        // 4. עדכון קטגוריה קיימת
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiftCategory category)
        {
            var success = await _categoryService.UpdateAsync(id, category);
            if (!success)
            {
                return NotFound($"Update failed. Category {id} not found.");
            }
            return NoContent();
        }

        // 5. מחיקת קטגוריה
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _categoryService.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"Delete failed. Category {id} not found.");
            }
            return Ok(new { message = "Category deleted successfully." });
        }
    }
}