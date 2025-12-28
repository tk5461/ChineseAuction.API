using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ChineseAuctionAPI.Repositories
    {
        public class CategoryRpository : ICategoryRpository
        {
            private readonly SalesContextDB _context;
            private readonly IConfiguration _config;


        public CategoryRpository(SalesContextDB context , IConfiguration config)
            {
                _context = context;
                _config = config;
        }

            public async Task<IEnumerable<GiftCategory>> GetAllAsync()
            {
                return await _context.Categories.ToListAsync();
            }
            public async Task<GiftCategory?> GetByIdAsync(int id)
            {
                return await _context.Categories.FindAsync(id);
            }
            public async Task<GiftCategory> AddAsync(GiftCategory category)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return category;
            }

            public async Task<bool> UpdateAsync(GiftCategory category)
            {
                _context.Categories.Update(category);
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
            public async Task<bool> DeleteAsync(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) return false;

                _context.Categories.Remove(category);
                var affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }
        }
  }
