using Core.Models;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IDoctorService
    {
        Task<Result> AddDoctorAsync(string fullName, int cabinet, string specification, int district);
        Task<Result> DeleteDoctorAsync(Guid id);
        Task<List<Doctor>> GetAllDoctorsAsync(string sortField, int page);
        Task<Result<Doctor>> GetByIdAsync(Guid id);
        Task<Result> UpdateDoctorAsync(Guid id, string fullName, int cabinet, string specification, int district);
    }
}