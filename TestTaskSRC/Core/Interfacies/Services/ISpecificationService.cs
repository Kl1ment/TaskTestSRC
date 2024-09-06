using Core.Models;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface ISpecificationService
    {
        Task<Result> AddSpecificationAsync(string name);
        Task<List<Specification>> GetAllSpecificationsAsync(int page);
        Task<Result> DeleteSpecificationAsync(string name);
    }
}