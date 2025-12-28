using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;

public class GiftService : IGiftService
{
    private readonly IGiftRepository _repository;
    public GiftService(IGiftRepository repository) 
    { 
        _repository = repository; 
    }

    public async Task<Gift> CreateGiftAsync(GiftDTO dto)
    {
        var gift = new Gift
        {
            Name = dto.Name,
            Description = dto.Description,
            Qeuntity = dto.Quantity,
            price = dto.Price,
            Image = dto.Image,
            CategoryId = dto.CategoryId,
            IdDonor = dto.IdDonor,
        };
        return await _repository.AddAsync(gift);
    }

    public async Task<IEnumerable<Gift>> GetAllGiftsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Gift?> GetGiftByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> DeleteGiftAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}