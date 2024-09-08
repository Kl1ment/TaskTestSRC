using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IPatientService
    {
        Task<Result> AddPatientAsync(string surname, string name, string patronymic, string address, DateTime birthDate, string sex, Guid districtId);
        Task<Result> DeleteAsync(Guid patientId);
        Task<List<PatientDTO>> GetAllPatientsAsync(string sortField, int page);
        Task<Result<Patient>> GetPatientByIdAsync(Guid patientId);
        Task<Result> UpdatePatientAsync(Guid patientId, string surname, string name, string patronymic, string address, DateTime birthDate, string sex, Guid districtId);
    }
}