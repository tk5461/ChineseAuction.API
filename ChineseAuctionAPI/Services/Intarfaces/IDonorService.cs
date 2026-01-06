using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Services.Intarfaces
{
    public interface IDonorService
    {
        Task<IEnumerable<Donor>> GetAllDonorsAsync();
        Task<Donor> GetDonorByIdAsync(int id);
        Task<bool> CreateAsync(DonorDTO dto); 
        Task<bool> UpdateAsync(int id, DonorDTO dto); 
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<GiftDTO>> GetGiftsasync(int IdDonor);
        Task<IEnumerable<Donor>> GetDonorByNameAsync(string name);
        Task<IEnumerable<Donor>> GetDonorByEmailAsync(string Email);
        Task<Donor> GetDonorByGiftAsync(string Gift);

    }
}