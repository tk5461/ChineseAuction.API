using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Repositories.Intarfaces
{
    public interface IDonorRepository
    {
        Task<Donor> AddAsync(Donor donor);
        Task DeleteAsync(int id);
        Task<IEnumerable<Donor>> GetAllAsync();
        Task<Donor> GetByIdAsync(int id);
        Task UpdateAsync(Donor donor);
        Task<IEnumerable<Gift>>? GetGiftsAsync(int IdDonor);
    }
}
