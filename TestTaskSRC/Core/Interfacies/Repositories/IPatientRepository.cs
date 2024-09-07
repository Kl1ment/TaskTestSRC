using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public enum PatientSortField
    {
        Surname,
        Name,
        Patronymic,
        Address,
        BirthDate,
        Sex,
        District
    }

    public interface IPatientRepository
    {
        Task<Result> AddAsync(Patient patient);
        Task<Result> DeleteAsync(Guid id);
        Task<List<PatientDTO>> GetAsync(PatientSortField sortField, int page);
        Task<Result<Patient>> GetByIdAsync(Guid id);
        Task<Result> UpdateAsync(Patient patient);
    }
}