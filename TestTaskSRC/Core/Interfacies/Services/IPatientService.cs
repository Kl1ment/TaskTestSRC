using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IPatientService
    {
        Task<Result> AddPatientAsync(string surname, string name, string patronymic, string address, DateTime birthDate, string sex, Guid districtId);
        Task<Result> DeleteAsync(Guid id);
        Task<List<PatientDTO>> GetAllPatientsAsync(string sortField, int page);
        Task<Result<Patient>> GetPatientByIdAsync(Guid id);
        Task<Result> UpdatePatientAsync(Guid id, string surname, string name, string patronymic, string address, DateTime birthDate, string sex, Guid districtId);
    }
}