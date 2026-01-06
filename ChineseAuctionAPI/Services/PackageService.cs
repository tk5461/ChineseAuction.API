using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories.Intarfaces;
using ChineseAuctionAPI.Services.Intarfaces;

namespace ChineseAuctionAPI.Services
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _repository;
        private readonly IConfiguration _config;
        private readonly ILogger<PackageService> _logger;


        public PackageService(IPackageRepository repository, IConfiguration config ,ILogger<PackageService> logger)
        {
            _repository = repository;
            _config = config;
            _logger = logger;
        }

        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            try
            {
                var packages = await _repository.GetAllAsync();
                return packages.Select(p => new Package
                {
                    IdPackage = p.IdPackage,
                    Name = p.Name,
                    Price = p.Price,
                    Amount_Regular = p.Amount_Regular,
                    Amount_Premium = p.Amount_Premium
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving packages.", ex);
            }

        }

        public async Task<Package> CreatePackageAsync(PackageDTO dto)
        {
            try
            {
                var package = new Package
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Price = dto.Price,
                    Amount_Regular = dto.Amount_Regular,
                    Amount_Premium = dto.Amount_Premium
                };

                await _repository.AddAsync(package);
                await _repository.SaveChangesAsync();

                return package;
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה ביצירת חבילה חדשה במסד הנתונים", ex);
            }
        }
        public async Task<PackageDTO?> GetPackageByIdAsync(int id)
        {
            try
            {
                var p = await _repository.GetByIdAsync(id);
                if (p == null) return null;

                return new PackageDTO
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Amount_Regular = p.Amount_Regular,
                    Amount_Premium = p.Amount_Premium
                };
            }
            catch (Exception ex)
            {

                throw new Exception($"Error occurred while retrieving package with ID {id}.", ex);
            }

        }
        public async Task<bool> UpdatePackageAsync(int id, PackageDTO dto)
        {
            try
            {
                var existingPackage = await _repository.GetByIdAsync(id);
                if (existingPackage == null) return false;

                // עדכון השדות
                existingPackage.Name = dto.Name;
                existingPackage.Description = dto.Description;
                existingPackage.Price = dto.Price;
                existingPackage.Amount_Regular = dto.Amount_Regular;
                existingPackage.Amount_Premium = dto.Amount_Premium;

                _repository.Update(existingPackage); // פעולה סינכרונית ב-Repository
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating package with ID {id}.", ex);
            }

        }

        public async Task<bool> DeletePackageAsync(int id)
        {
            try
            {
                var package = await _repository.GetByIdAsync(id);
                if (package == null) return false;

                _repository.Delete(package);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error occurred while Delete package with ID {id}.", ex);
            }

        }

    }
}
