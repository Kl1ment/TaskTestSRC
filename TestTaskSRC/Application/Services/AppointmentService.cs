using Core;
using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
    {
        public async Task<Result<Appointment>> GetAppointmentByIdAsync(Guid appointmentId)
        {
            return await appointmentRepository.GetByIdAsync(appointmentId);
        }

        public async Task<Result> AddAppointmentAsync(Guid patientId, Guid doctorId, DateTime dateTime)
        {
            var appointment = Appointment.Create(
                Guid.NewGuid(),
                patientId,
                doctorId,
                dateTime);

            return await appointmentRepository.AddAsync(appointment);
        }

        public async Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid patientId, int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            return await appointmentRepository.GetPatientAppointmentsAsync(patientId, page);
        }

        public async Task<List<AppointmentDTO>> GetDoctorAppointmentsAsync(Guid doctorId, int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            return await appointmentRepository.GetDoctorAppointmentsAsync(doctorId, page);
        }

        public async Task<Result> UpdateAppointmentAsync(Guid appointmentId, Guid patientId, Guid doctorId, DateTime dateTime)
        {
            var appointment = Appointment.Create(
                appointmentId,
                patientId,
                doctorId,
                dateTime);

            return await appointmentRepository.UpdateAsync(appointment);
        }

        public async Task<Result> DeleteAppointmentAsync(Guid appointmentId)
        {
            return await appointmentRepository.DeleteAsync(appointmentId);
        }
    }
}
