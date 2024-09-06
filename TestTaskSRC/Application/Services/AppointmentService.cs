using Core;
using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
    {
        public async Task<Result<AppointmentCreator>> GetAppointmentByIdAsync(Guid id)
        {
            return await appointmentRepository.GetByIdAsync(id);
        }

        public async Task<Result> AddAppointmentAsync(Guid patientId, Guid doctorId, DateTime dateTime)
        {
            var appointment = AppointmentCreator.Create(
                Guid.NewGuid(),
                patientId,
                doctorId,
                dateTime);

            return await appointmentRepository.AddAsync(appointment);
        }

        public async Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid id, int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            return await appointmentRepository.GetPatientAppointmentsAsync(id, page);
        }

        public async Task<Result> UpdateAppointmentAsync(Guid patientId, Guid doctorId, DateTime dateTime)
        {
            var appointment = AppointmentCreator.Create(
                Guid.NewGuid(),
                patientId,
                doctorId,
                dateTime);

            return await appointmentRepository.UpdateAsync(appointment);
        }

        public async Task<Result> DeleteAppointmentAsync(Guid id)
        {
            return await appointmentRepository.DeleteAsync(id);
        }
    }
}
