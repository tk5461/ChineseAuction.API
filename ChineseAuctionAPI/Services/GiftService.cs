using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories;
using ChineseAuctionAPI.Repositories.Intarfaces;
using Microsoft.Extensions.Logging;

public class GiftService : IGiftService
{
    private readonly IGiftRepository _repository;
    private readonly ILogger<GiftService> _logger;
    private readonly IConfiguration _config;
    private readonly IEmailService _emailService; 
    private readonly IuserRepository _UserRepository;

    public GiftService(IGiftRepository repository, ILogger<GiftService> logger, IConfiguration config , IEmailService emailService
        , IuserRepository UserRepository)
    {
        _repository = repository;
        _logger = logger;
        _config = config;
        _emailService = emailService;
        _UserRepository = UserRepository;
    }

    public async Task<Gift> CreateGiftAsync(GiftDTO dto)
    {
        try
        {
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "שגיאה ביצירת מתנה חדשה: {GiftName}", dto.Name);
                throw new Exception("אירעה שגיאה בעת שמירת המתנה במערכת.");
            }
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
            return false; 
        }
    }


    public async Task<winner?> DrawWinnerForGiftAsync(int giftId)
    {
        var gift = await _repository.GetGiftWithOrdersAndUsersAsync(giftId);
        if (gift == null || gift.IsDrawn) return null;

        var ticketPool = gift.GiftOrders
            .SelectMany(go => Enumerable.Repeat(go.Order.userId, go.Amount))
            .ToList();

        if (!ticketPool.Any()) return null;

        int randomIndex = Random.Shared.Next(ticketPool.Count);
        int winnerUserId = ticketPool[randomIndex];

        var winnerRecord = new winner
        {
            IdGift = giftId,
            UserId = winnerUserId
        };

        gift.IsDrawn = true;
        await _repository.AddWinnerAsync(winnerRecord);

        try
        {
            var winnerUser = await _UserRepository.GetByIdAsync(winnerUserId);

            if (winnerUser != null && !string.IsNullOrEmpty(winnerUser.Email))
            {
                // בניית גוף המייל בעזרת ה-HTML שיצרנו
                string emailBody = _emailService.CreateWinnerTemplate(winnerUser.FirstName, gift.Name);

                _emailService.SendEmailAsync(winnerUser.Email, "מזל טוב! זכית בהגרלה הסינית 🎁", emailBody);

                _logger.LogInformation("מייל ברכה נשלח לזוכה {UserId} על המתנה {GiftId}", winnerUserId, giftId);
            }
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, "ההגרלה הצליחה אך שליחת המייל לזוכה {UserId} נכשלה", winnerUserId);
        }

        return winnerRecord;
    }

    public async Task<IEnumerable<Gift?>> GetByNameGiftAsync(string nameGift)
    {
        try
        {
        return await _repository.GetByNameGiftAsync(nameGift);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "שגיאה בשליפת מתנה : {GiftId}", nameGift);
            throw new Exception($"אירעה שגיאה בחיפוש מתנה  {nameGift}.");
        }
    }

    public async Task<IEnumerable<Gift?>> GetByNameDonorAsync(string nameDonor)
    {
        try
        {
            return await _repository.GetByNameDonorAsync(nameDonor);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "שגיאה בשליפת מתנה שנתרם עי: {GiftId}", nameDonor);
            throw new Exception($"אירעה שגיאה בחיפוש מתנה שנתרם עי   {nameDonor}.");
        }
    }

    public async Task<IEnumerable<GiftDTONew?>> GetByNumOfBuyersAsync(int num)
    {
        try
        {
           var gifts = await _repository.GetByNumOfBuyersAsync(num);

             var result = gifts.Select(g => new GiftDTONew
            {
                IdGift = g.IdGift,
                Name = g.Name,
                Description = g.Description,
                Price = g.price,
                NumOfBuyers = g.GiftOrders?.Count() ?? 0
            }).ToList();
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "אירעה שגיאה בחיפוש מתנה עם מס רוכשים {GiftId}", num);
            throw new Exception($"אירעה שגיאה בחיפוש מתנה עם {num} רוכשים.");
        }
    }

    public async Task<IEnumerable<Gift?>> SortByAmountPepole()
    {
        try
        {
            return await _repository.SortByAmountPepole();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SortByAmountPepole:");
            throw new Exception($"SortByAmountPepole");
        }
    }

    public async Task<IEnumerable<Gift?>> SortByPrice()
    {
        try
        {
            return await _repository.SortByPrice();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SortByPrice:");
            throw new Exception($"SortByPrice");
        }
    }
}