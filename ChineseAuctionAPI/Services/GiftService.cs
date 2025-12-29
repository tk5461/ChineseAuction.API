using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;
using Microsoft.Extensions.Logging;

public class GiftService : IGiftService
{
    private readonly IGiftRepository _repository;
    private readonly ILogger<GiftService> _logger;
    private readonly IConfiguration _config;

    public GiftService(IGiftRepository repository, ILogger<GiftService> logger, IConfiguration config)
    {
        _repository = repository;
        _logger = logger;
        _config = config;
    }

    public async Task<Gift> CreateGiftAsync(GiftDTO dto)
    {
        //try
        //{
            var gift = new Gift
            {
                Name = dto.Name,
                Description = dto.Description,
                Quantity = dto.Quantity,
                price = dto.Price,
                Image = dto.Image,
                CategoryId = dto.CategoryId,
                IdDonor = dto.IdDonor,
            };
            return await _repository.AddAsync(gift);
        //}
        //catch (Exception ex)
        //{
        //    _logger.LogError(ex, "שגיאה ביצירת מתנה חדשה: {GiftName}", dto.Name);
        //    throw new Exception("אירעה שגיאה בעת שמירת המתנה במערכת.");
        //}
    }

    public async Task<IEnumerable<Gift>> GetAllGiftsAsync()
    {
        try
        {
            return await _repository.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "שגיאה בשליפת רשימת המתנות.");
            throw new Exception("לא ניתן לשלוף את רשימת המתנות כרגע.");
        }
    }

    public async Task<Gift?> GetGiftByIdAsync(int id)
    {
        try
        {
            return await _repository.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "שגיאה בשליפת מתנה עם מזהה: {GiftId}", id);
            throw new Exception($"אירעה שגיאה בחיפוש מתנה מספר {id}.");
        }
    }

    public async Task<bool> DeleteGiftAsync(int id)
    {
        try
        {
            return await _repository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "שגיאה במחיקת מתנה עם מזהה: {GiftId}", id);
            return false; // במקרה של מחיקה, לעיתים נרצה להחזיר false במקום לזרוק שגיאה
        }
    }
}