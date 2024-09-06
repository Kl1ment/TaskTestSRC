using Core.Models;
using CSharpFunctionalExtensions;

namespace DataAccess.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Result> AddAsync(AppointmentCreator appointment);
        Task<Result> DeleteAsync(Guid id);
        Task<List<AppointmentDTO>> GetDoctorAppointmentsAsync(Guid id, int page);
        Task<Result<AppointmentCreator>> GetByIdAsync(Guid id);
        Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid id, int page);
        Task<Result> UpdateAsync(AppointmentCreator appointment);
    }
}