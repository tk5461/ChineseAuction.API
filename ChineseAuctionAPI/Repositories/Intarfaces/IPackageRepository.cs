using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Repositories.Intarfaces
{
    public interface IPackageRepository
    {
        Task<bool> AddAsync(Package package);
        Task<bool> Delete(Package package);
        Task<IEnumerable<Package>> GetAllAsync();
        Task<Package> GetByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        Task<bool> Update(Package package);
    }
}