using Core.Models;
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
        Task<List<Doctor>> GetAsync(DoctorSortField sortField, int page);
        Task<Result<Doctor>> GetByIdAsync(Guid id);
        Task<Result> UpdateAsync(Doctor doctor);
    }
}