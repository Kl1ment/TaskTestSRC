using Core;
using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class CabinetService(ICabinetRepository cabinetRepository) : ICabinetService
    {
        public async Task<Result> AddCabinetAsync(int number)
        {
            var cabinet = Cabinet.Create(
                Guid.NewGuid(),
                number);

            return await cabinetRepository.AddAsync(cabinet);
        }

        public async Task<List<Cabinet>> GetAllCabinetsAsync(int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            return await cabinetRepository.GetAllAsync(page);
        }

        public async Task<Result> DeleteCabinetAsync(int number)
        {
            return await cabinetRepository.DeleteAsync(number);
        }
    }
}
