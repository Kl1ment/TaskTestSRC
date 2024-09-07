using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public enum DoctorSortField
    {
        FullName,
        Cabinet,
        Specification,
        District
    }

    public interface IDoctorRepository
    {
        Task<Result> AddAsync(Doctor doctor);
        Task<Result> DeleteAsync(Guid id);
        Task<List<DoctorDOT>> GetAsync(DoctorSortField sortField, int page);
        Task<Result<Doctor>> GetByIdAsync(Guid id);
        Task<Result> UpdateAsync(Doctor doctor);
    }
}