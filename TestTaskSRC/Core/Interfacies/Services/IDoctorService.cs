using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IDoctorService
    {
        Task<Result> AddDoctorAsync(string fullName, Guid cabinetId, Guid specificationId, Guid districtId);
        Task<Result> DeleteDoctorAsync(Guid doctorId);
        Task<List<DoctorDOT>> GetAllDoctorsAsync(string sortField, int page);
        Task<Result<Doctor>> GetByIdAsync(Guid doctorId);
        Task<Result> UpdateDoctorAsync(Guid doctorId, string fullName, Guid cabinetId, Guid specificationId, Guid districtId);
    }
}