using Core.Models;
using CSharpFunctionalExtensions;

namespace Application.Services
{
    public interface IAppointmentService
    {
        Task<Result> AddAppointmentAsync(Guid patientId, Guid doctorId, DateTime dateTime);
        Task<Result> DeleteAppointmentAsync(Guid id);
        Task<Result<Appointment>> GetAppointmentByIdAsync(Guid id);
        Task<Result> UpdateAppointmentAsync(Guid patientId, Guid doctorId, DateTime dateTime);
    }
}