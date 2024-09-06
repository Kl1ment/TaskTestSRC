using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AppointmentRepository(SRCDbContext context) : IAppointmentRepository
    {
        private const int PageSize = 10;

        public async Task<Result> AddAsync(AppointmentCreator appointment)
        {
            try
            {
                var appointmentEntity = new AppointmentEntity
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    DateTime = appointment.DateTime
                };

                await context.Appointments.AddAsync(appointmentEntity);
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid id, int page)
        {
            var appointmentEntity = await context.Patients
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Include(p => p.Appointments)
                .Select(p => p.Appointments)
                .Skip(page - 1)
                .Take(PageSize)
                .FirstOrDefaultAsync();

            return appointmentEntity?.Select(a => new AppointmentDTO(
                a.Id,
                a.PatientEntity.Surname,
                a.PatientEntity.Name,
                a.PatientEntity.Patronymic,
                a.DoctorEntity.FullName,
                a.DoctorEntity.Specification,
                a.DateTime,
                a.DoctorEntity.Cabinet)).ToList() ?? [];
        }

        public async Task<List<AppointmentDTO>> GetDoctorAppointmentsAsync(Guid id, int page)
        {
            var appointmentEntity = await context.Doctors
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Include(p => p.Appointments)
                .Select(p => p.Appointments)
                .Skip(page - 1)
                .Take(PageSize)
                .FirstOrDefaultAsync();

            return appointmentEntity?.Select(a => new AppointmentDTO(
                a.Id,
                a.PatientEntity.Surname,
                a.PatientEntity.Name,
                a.PatientEntity.Patronymic,
                a.DoctorEntity.FullName,
                a.DoctorEntity.Specification,
                a.DateTime,
                a.DoctorEntity.Cabinet)).ToList() ?? [];
        }

        public async Task<Result<AppointmentCreator>> GetByIdAsync(Guid id)
        {
            var appointmentEntity = await context.Appointments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointmentEntity == null)
                return Result.Failure<AppointmentCreator>("Appointment was not found");

            return AppointmentCreator.Create(
                appointmentEntity.Id,
                appointmentEntity.PatientId,
                appointmentEntity.DoctorId,
                appointmentEntity.DateTime);
        }

        public async Task<Result> UpdateAsync(AppointmentCreator appointment)
        {
            try
            {
                await context.Appointments
                    .Where(a => a.Id == appointment.Id)
                    .ExecuteUpdateAsync(p => p
                        .SetProperty(a => a.PatientId, appointment.PatientId)
                        .SetProperty(a => a.DoctorId, appointment.DoctorId)
                        .SetProperty(a => a.DateTime, appointment.DateTime));

                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                await context.Appointments
                    .Where(a => a.Id == id)
                    .ExecuteDeleteAsync();

                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
