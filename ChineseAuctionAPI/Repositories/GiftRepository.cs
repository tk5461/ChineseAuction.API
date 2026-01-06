using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.DTO;
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

    public async Task<Gift?> GetGiftWithOrdersAndUsersAsync(int giftId)
    {
        return await _context.Gifts
            .Include(g => g.GiftOrders)
                .ThenInclude(go => go.Order)
                .ThenInclude(o => o.User)
            .FirstOrDefaultAsync(g => g.IdGift == giftId);
    }
    public async Task AddWinnerAsync(winner winner)
    {
        await _context.Winners.AddAsync(winner);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Gift?>> GetByNameGiftAsync(string name)
    {
        return await _context.Gifts.Where(gift => gift.Name.Contains(name)).ToArrayAsync();
    }

    public async Task<IEnumerable<Gift?>> GetByNameDonorAsync(string nameDonor)
    {
        return await _context.Gifts.Where(gift => gift.Donor.F_name.Contains(nameDonor)).ToArrayAsync();
    }

    public async Task<IEnumerable<Gift?>> GetByNumOfBuyersAsync(int num)
    {
        return await _context.Gifts
                .Include(g => g.GiftOrders)
                 .Where(g => g.GiftOrders.Count() >= num)
                .ToListAsync(); 
    }

    public async Task<IEnumerable<Gift?>> SortByPrice()
    {
        return await _context.Gifts.OrderByDescending(p=>p.price).ToArrayAsync();
    }

    public async Task<IEnumerable<Gift?>> SortByAmountPepole()
    {
        return await _context.Gifts.OrderByDescending(g => g.GiftOrders.Sum(go => go.Amount)).ToListAsync();
    }
}

