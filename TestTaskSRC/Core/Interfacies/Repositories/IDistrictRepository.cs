using Core.Models;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public interface IDistrictRepository
    {
        Task<Result> AddAsync(District district);
        Task<List<District>> GetAllAsync(int page);
        Task<Result> DeleteAsync(int number);
    }
}