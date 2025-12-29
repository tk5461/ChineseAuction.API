using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

public class GiftRepository : IGiftRepository
{
    private readonly SalesContextDB _context;
    public GiftRepository(SalesContextDB context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Gift>> GetAllAsync()
    { 
        return await _context.Gifts.Include(g => g.Category).Include(g => g.Donor).ToListAsync();
    }
    public async Task<Gift?> GetByIdAsync(int id)
    {
        return await _context.Gifts.Include(g => g.Category).Include(g => g.Donor)
                            .FirstOrDefaultAsync(g => g.IdGift == id);
    }

    public async Task<Gift> AddAsync(Gift gift)
    {
        await _context.Gifts.AddAsync(gift);
        await _context.SaveChangesAsync();
        return await _context.Gifts
         .Include(g => g.Donor)
         .Include(g => g.Category)
         .FirstAsync(g => g.IdGift == gift.IdGift);
    }

    public async Task<bool> UpdateAsync(Gift gift)
    {
        _context.Gifts.Update(gift);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var gift = await _context.Gifts.FindAsync(id);
        if (gift == null) return false;
        _context.Gifts.Remove(gift);
        return await _context.SaveChangesAsync() > 0;
    }
}