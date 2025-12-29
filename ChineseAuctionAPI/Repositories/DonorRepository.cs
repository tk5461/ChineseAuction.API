using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly SalesContextDB _context;
        public DonorRepository(SalesContextDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donor>> GetAllAsync()
        {
            return await _context.Donors.ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(int id)
        {
           return await _context.Donors.FindAsync(id);
        }

        public async Task<Donor> AddAsync(Donor donor)
        {
                await _context.Donors.AddAsync(donor);
                await _context.SaveChangesAsync();
                return donor;
        }

        public async Task UpdateAsync(Donor donor)
        {
         
             _context.Entry(donor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
  
        }

        public async Task DeleteAsync(int id)
        {
       
                var donor = await _context.Donors.FindAsync(id);
                if (donor != null)
                {
                    _context.Donors.Remove(donor);
                    await _context.SaveChangesAsync();
                }
        }

        public async Task<IEnumerable<Gift>>? GetGiftsAsync(int  IdDonor)
        {
         return  await _context.Gifts
                .Where(g=>IdDonor==g.IdDonor)
                .Include(c=>c.Category)
                .ToListAsync();
        }
    }
}
