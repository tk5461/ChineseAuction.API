using ChineseAuctionAPI.Models;

public interface IGiftRepository
{
    Task<Gift?> GetGiftWithOrdersAndUsersAsync(int giftId);
    Task<IEnumerable<Gift>> GetAllAsync();
    Task<Gift?> GetByIdAsync(int id);
    Task<IEnumerable<Gift?>> GetByNameGiftAsync(string nameGift);
    Task<IEnumerable<Gift?>> GetByNameDonorAsync(string nameDonor);
    Task<IEnumerable<Gift?>> GetByNumOfBuyersAsync(int num);

    Task<Gift> AddAsync(Gift gift);
    Task<bool> UpdateAsync(Gift gift);
    Task<bool> DeleteAsync(int id);
    Task AddWinnerAsync(winner winner);
    Task<IEnumerable<Gift?>> SortByPrice();
    Task<IEnumerable<Gift?>> SortByAmountPepole();


}