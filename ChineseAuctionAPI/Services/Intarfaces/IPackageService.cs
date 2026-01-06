using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;

namespace ChineseAuctionAPI.Services.Intarfaces
{
    public interface IPackageService
    {
        Task<Package> CreatePackageAsync(PackageDTO dto);
        Task<bool> DeletePackageAsync(int id);
        Task<IEnumerable<Package>> GetAllPackagesAsync();
        Task<PackageDTO?> GetPackageByIdAsync(int id);
        Task<bool> UpdatePackageAsync(int id, PackageDTO dto);
    }
}