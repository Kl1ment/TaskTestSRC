using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Result> AddAsync(Appointment appointment);
        Task<Result> DeleteAsync(Guid id);
        Task<Result<Appointment>> GetByIdAsync(Guid id);
        Task<List<AppointmentDTO>> GetDoctorAppointmentsAsync(Guid doctorId, int page);
        Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid patientId, int page);
        Task<Result> UpdateAsync(Appointment appointment);
    }
}