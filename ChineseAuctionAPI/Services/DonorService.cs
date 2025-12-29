using ChineseAuctionAPI.DTO;
using ChineseAuctionAPI.Models;
using ChineseAuctionAPI.Repositories.Intarfaces;
using ChineseAuctionAPI.Services.Intarfaces;
using Microsoft.Extensions.Logging;

namespace ChineseAuctionAPI.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _repository;
        private readonly ILogger<DonorService> _logger; // הוספת לוגר לתיעוד שגיאות
        private readonly IConfiguration _config;

        public DonorService(IDonorRepository repository, ILogger<DonorService> logger, IConfiguration config)
        {
            _repository = repository;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
        {
            try
            {
                var donors = await _repository.GetAllAsync();
                return donors.Select(d => new Donor
                {
                    IdDonor = d.IdDonor,
                    F_name = d.F_name,
                    L_name = d.L_name,
                    Email = d.Email,
                    phonNumber = d.phonNumber
                });
            }
            catch (Exception ex)
            {
            //    _logger.LogError(ex, "Error occurred while fetching all donors.");
                throw; // זריקת השגיאה הלאה ל-Controller
            }
        }

        public async Task<Donor> GetDonorByIdAsync(int id)
        {
            try
            {
                var donor = await _repository.GetByIdAsync(id);
                if (donor == null) return null;

                return new Donor
                {
                    IdDonor = donor.IdDonor,
                    F_name = donor.F_name,
                    L_name = donor.L_name,
                    Email = donor.Email,
                    phonNumber = donor.phonNumber
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching donor with ID {id}.");
                throw;
            }
        }

        public async Task<bool> CreateAsync(DonorDTO dto)
        {
            try
            {
                var donor = new Donor
                {
                    F_name = dto.FirstName,
                    L_name = dto.LastName,
                    Email = dto.Email,
                    phonNumber = dto.PhoneNumber
                };
                await _repository.AddAsync(donor);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new donor.");
                return false; // במקרה של שגיאה נחזיר false
            }
        }

        public async Task<bool> UpdateAsync(int id, DonorDTO dto)
        {
            try
            {
                var donor = await _repository.GetByIdAsync(id);
                if (donor != null)
                {
                    donor.F_name = dto.FirstName;
                    donor.L_name = dto.LastName;
                    donor.Email = dto.Email;
                    donor.phonNumber = dto.PhoneNumber;

                    await _repository.UpdateAsync(donor);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating donor with ID {id}.");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting donor with ID {id}.");
                return false;
            }
        }

        public async Task<IEnumerable<GiftDTO>> GetGiftsasync(int IdDonor)
        {
            try
            {
            var gifts = await _repository.GetGiftsAsync(IdDonor);
            return gifts.Select(g => new GiftDTO
                {
                    Name = g.Name,
                    Description = g.Description,
                    CategoryId = g.CategoryId,
                    Quantity = g.Quantity,
                    Price = g.price,
                    Image = g.Image,
                    IdDonor = g.IdDonor
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception("Cannot GetGifts by IdDonor", ex);
            }
        }    
}
}
