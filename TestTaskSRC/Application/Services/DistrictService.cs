using Core;
using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class DistrictService(IDistrictRepository districtRepository) : IDistrictService
    {
        public async Task<Result> AddDistrictAsync(int number)
        {
            var district = District.Create(
                Guid.NewGuid(),
                number);

            return await districtRepository.AddAsync(district);
        }

        public async Task<List<District>> GetAllDistrictsAsync(int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            return await districtRepository.GetAllAsync(page);
        }

        public async Task<Result> DeleteDistrictAsync(int number)
        {
            return await districtRepository.DeleteAsync(number);
        }
    }
}
