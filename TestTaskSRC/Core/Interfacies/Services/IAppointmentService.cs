using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IAppointmentService
    {
        Task<Result> AddAppointmentAsync(Guid patientId, Guid doctorId, DateTime dateTime);
        Task<Result> DeleteAppointmentAsync(Guid appointmentId);
        Task<Result<Appointment>> GetAppointmentByIdAsync(Guid appointmentId);
        Task<List<AppointmentDTO>> GetDoctorAppointmentsAsync(Guid doctorId, int page);
        Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid patientId, int page);
        Task<Result> UpdateAppointmentAsync(Guid appointmentId, Guid patientId, Guid doctorId, DateTime dateTime);
    }
}