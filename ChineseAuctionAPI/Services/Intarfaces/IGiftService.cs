using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;

public interface IGiftService
{
    Task<winner?> DrawWinnerForGiftAsync(int giftId);
    Task<Gift> CreateGiftAsync(GiftDTO dto);
    Task<bool> DeleteGiftAsync(int id);
    Task<IEnumerable<Gift>> GetAllGiftsAsync();
    Task<Gift?> GetGiftByIdAsync(int id);
    Task<IEnumerable<Gift?>> GetByNameGiftAsync(string nameGift);
    Task<IEnumerable<Gift?>> GetByNameDonorAsync(string nameDonor);
    Task<IEnumerable<GiftDTONew?>> GetByNumOfBuyersAsync(int num);
    Task<IEnumerable<Gift?>> SortByAmountPepole();
    Task<IEnumerable<Gift?>> SortByPrice();
}
