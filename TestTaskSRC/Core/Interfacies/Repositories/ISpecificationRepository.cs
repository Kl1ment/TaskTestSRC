using Core.Models;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public interface ISpecificationRepository
    {
        Task<Result> AddAsync(Specification specification);
        Task<List<Specification>> GetAllAsync(int page);
        Task<Result> DeleteAsync(Guid id);
    }
}