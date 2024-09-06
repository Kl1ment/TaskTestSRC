using Core.Models;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IPatientService
    {
        Task<Result> AddPatientAsync(string surname, string name, string patronymic, string address, DateTime birthDate, string sex, int district);
        Task<Result> DeleteAsync(Guid id);
        Task<List<Patient>> GetAllPatientsAsync(string sortField, int page);
        Task<Result<Patient>> GetPatientByIdAsync(Guid id);
        Task<Result> UpdatePatientAsync(Guid id, string surname, string name, string patronymic, string address, DateTime birthDate, string sex, int district);
    }
}