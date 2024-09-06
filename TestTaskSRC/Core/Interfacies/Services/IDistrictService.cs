using Core.Models;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IDistrictService
    {
        Task<Result> AddDistrictAsync(int number);
        Task<List<District>> GetAllDistrictsAsync(int page);
        Task<Result> DeleteDistrictAsync(int number);
    }
}