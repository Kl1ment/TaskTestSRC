﻿using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class AppointmentRepository(SRCDbContext context) : IAppointmentRepository
    {
        private const int PageSize = 10;

        public async Task<Result> AddAsync(Appointment appointment)
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

        public async Task<List<AppointmentDTO>> GetPatientAppointmentsAsync(Guid patientId, int page)
        {
            var appointmentEntity = await context.Appointments
                .AsNoTracking()
                .Where(a => a.PatientId == patientId)
                .Include(a => a.PatientEntity)
                .Include(a => a.DoctorEntity)
                .ThenInclude(d => d.SpecificationEntity)
                .Include(a => a.DoctorEntity)
                .ThenInclude(d => d.CabinetEntity)
                .Skip(page - 1)
                .Take(PageSize)
                .ToListAsync();

            return appointmentEntity.Select(a => new AppointmentDTO(
                a.Id,
                a.PatientEntity.Surname,
                a.PatientEntity.Name,
                a.PatientEntity.Patronymic,
                a.DoctorEntity.FullName,
                a.DoctorEntity.SpecificationEntity?.Name,
                a.DateTime,
                a.DoctorEntity.CabinetEntity?.Number)).ToList();
        }

        public async Task<List<AppointmentDTO>> GetDoctorAppointmentsAsync(Guid doctorId, int page)
        {
            var appointmentEntity = await context.Appointments
                .AsNoTracking()
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.PatientEntity)
                .Include(a => a.DoctorEntity)
                .ThenInclude(d => d.SpecificationEntity)
                .Include(a => a.DoctorEntity)
                .ThenInclude(d => d.CabinetEntity)
                .Skip(page - 1)
                .Take(PageSize)
                .ToListAsync();

            return appointmentEntity.Select(a => new AppointmentDTO(
                a.Id,
                a.PatientEntity.Surname,
                a.PatientEntity.Name,
                a.PatientEntity.Patronymic,
                a.DoctorEntity.FullName,
                a.DoctorEntity.SpecificationEntity?.Name,
                a.DateTime,
                a.DoctorEntity.CabinetEntity?.Number)).ToList();
        }

        public async Task<Result<Appointment>> GetByIdAsync(Guid id)
        {
            var appointmentEntity = await context.Appointments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointmentEntity == null)
                return Result.Failure<Appointment>("Appointment was not found");

            return Appointment.Create(
                appointmentEntity.Id,
                appointmentEntity.PatientId,
                appointmentEntity.DoctorId,
                appointmentEntity.DateTime);
        }

        public async Task<Result> UpdateAsync(Appointment appointment)
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
