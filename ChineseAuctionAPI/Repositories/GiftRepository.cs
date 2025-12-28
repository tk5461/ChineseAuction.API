using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

public class GiftRepository : IGiftRepository
{
    private readonly SalesContextDB _context;
    private readonly IConfiguration _config;

    public GiftRepository(SalesContextDB context, IConfiguration config)
    {
        _context = context;
        _config = config;
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
        return gift;
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