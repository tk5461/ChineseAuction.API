using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;

namespace ChineseAuctionAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRpository _categoryRepository;


        public CategoryService(ICategoryRpository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<GiftCategory>> GetAllAsync()
        {
            try
            {
                return await _categoryRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("שגיאה בשליפת כל הקטגוריות", ex);
            }
        }

        public async Task<GiftCategory?> GetByIdAsync(int id)
        {
            try
            {
                return await _categoryRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בשליפת קטגוריה מספר {id}", ex);
            }
        }

        public async Task<GiftCategory> AddAsync(CategoryDTO categoryDto)
        {
            var newCategory = new GiftCategory
            {
                Name = categoryDto.Name 
            };

            return await _categoryRepository.AddAsync(newCategory);
        }

        public async Task<bool> UpdateAsync(int id, GiftCategory category)
        {
            try
            {
                category.Id = id;
                return await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה בעדכון קטגוריה מספר {id}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _categoryRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"שגיאה במחיקת קטגוריה מספר {id}", ex);
            }
        }
    }

}
