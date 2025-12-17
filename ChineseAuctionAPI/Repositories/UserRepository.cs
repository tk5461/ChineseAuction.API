using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Repositories
{
    public class UserRepository : IuserRepository
    {
        private readonly SalesContextDB _context;

        public UserRepository(SalesContextDB context)
        { 
            _context = context; 
        } 

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;
            
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
           return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.userId == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.userId).ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
            .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                    .FirstOrDefaultAsync(p => p.userId == id);
        }


        public async Task<User?> GetUserWirhOrdersAsync(int userId)
        {
            return await _context.Users
                          .Include(u => u.Orders)
                          .FirstOrDefaultAsync(u => u.userId == userId);
        }
    }
}
