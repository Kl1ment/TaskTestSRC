using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Result> AddAsync(Appointment appointment);
        Task<Result> DeleteAsync(Guid id);
        Task<List<AppointmentDTO>> GetDoctorAppointmentsAsync(Guid id, int page);
        Task<Result<Appointment>> GetByIdAsync(Guid id);
        Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid id, int page);
        Task<Result> UpdateAsync(Appointment appointment);
    }
}