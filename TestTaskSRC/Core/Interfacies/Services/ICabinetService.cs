using Core.Models;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface ICabinetService
    {
        Task<Result> AddCabinetAsync(int number);
        Task<List<Cabinet>> GetAllCabinetsAsync(int page);
        Task<Result> DeleteCabinetAsync(Guid cabinetId);
    }
}