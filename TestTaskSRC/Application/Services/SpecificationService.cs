using Core;
using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class SpecificationService(ISpecificationRepository specificationRepository) : ISpecificationService
    {
        public async Task<Result> AddSpecificationAsync(string name)
        {
            var specification = Specification.Create(
                Guid.NewGuid(),
                name);

            return await specificationRepository.AddAsync(specification);
        }

        public async Task<List<Specification>> GetAllSpecificationsAsync(int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            return await specificationRepository.GetAllAsync(page);
        }

        public async Task<Result> DeleteSpecificationAsync(string name)
        {
            return await specificationRepository.DeleteAsync(name);
        }
    }
}
