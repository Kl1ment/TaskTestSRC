using Core.Models;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public interface ICabinetRepository
    {
        Task<Result> AddAsync(Cabinet cabinet);
        Task<List<Cabinet>> GetAllAsync(int page);
        Task<Result> DeleteAsync(int number);
    }
}