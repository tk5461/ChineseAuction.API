using ChineseAuctionAPI.Data;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly SalesContextDB _context;
        public PackageRepository(SalesContextDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Package>> GetAllAsync()
        {
            return await _context.Packages.ToListAsync();
        }
        public async Task<Package> GetByIdAsync(int id)
        {
            return await _context.Packages.FindAsync(id);
        }
        public async Task<bool> AddAsync(Package package)
        {
            await _context.Packages.AddAsync(package);
            return true;
        }
        public async Task<bool> Update(Package package)
        {
            _context.Packages.Update(package);
            return await Task.FromResult(true);
        }
        public async Task<bool> Delete(Package package)
        {
            _context.Packages.Remove(package);
            return await Task.FromResult(true);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
