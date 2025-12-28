using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;

public interface IGiftService
{
    Task<Gift> CreateGiftAsync(GiftDTO dto);
    Task<bool> DeleteGiftAsync(int id);
    Task<IEnumerable<Gift>> GetAllGiftsAsync();
    Task<Gift?> GetGiftByIdAsync(int id);
}