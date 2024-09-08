using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DoctorRepository(SRCDbContext context) : IDoctorRepository
    {
        private const int PageSize = 10;

        public async Task<Result> AddAsync(Doctor doctor)
        {
            try
            {
                var doctorEntity = new DoctorEntity
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    CabinetId = doctor.CabinetId,
                    SpecificationId = doctor.SpecificationId,
                    DistrictId = doctor.DistrictId
                };

                await context.Doctors.AddAsync(doctorEntity);
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<List<DoctorDOT>> GetAsync(DoctorSortField sortField, int page)
        {
            var query = context.Doctors
                .AsNoTracking()
                .Skip(page - 1)
                .Include(d => d.CabinetEntity)
                .Include(d => d.SpecificationEntity)
                .Include(d => d.DistrictEntity)
                .Take(PageSize);

            switch (sortField)
            {
                case DoctorSortField.FullName: query = query.OrderBy(d => d.FullName); break;

                case DoctorSortField.Cabinet:
                    query = query.OrderBy(d =>
                    d.CabinetEntity == null ? 0 : d.CabinetEntity.Number); break;

                case DoctorSortField.Specification:
                    query = query.OrderBy(d => 
                    d.SpecificationEntity == null ? "" : d.SpecificationEntity.Name); break;

                case DoctorSortField.District:
                    query = query.OrderBy(d =>
                    d.DistrictEntity == null ? 0 : d.DistrictEntity.Number); break;
            }

            var doctorEntities = await query.ToListAsync();

            return doctorEntities.Select(d => DoctorDOT.Create(
                d.Id,
                d.FullName,
                d.CabinetEntity?.Number,
                d.SpecificationEntity?.Name,
                d.DistrictEntity?.Number)).ToList();
        }

        public async Task<Result<Doctor>> GetByIdAsync(Guid id)
        {
            var doctorEntity = await context.Doctors
                .AsNoTracking()
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();

            if (doctorEntity == null)
                return Result.Failure<Doctor>("The doctor was not found");

            return Doctor.Create(
                doctorEntity.Id,
                doctorEntity.FullName,
                doctorEntity.CabinetId,
                doctorEntity.SpecificationId,
                doctorEntity.DistrictId);
        }

        public async Task<Result> UpdateAsync(Doctor doctor)
        {
            try
            {
                await context.Doctors
                    .Where(d => d.Id == doctor.Id)
                    .ExecuteUpdateAsync(p => p
                        .SetProperty(d => d.FullName, doctor.FullName)
                        .SetProperty(d => d.CabinetId, doctor.CabinetId)
                        .SetProperty(d => d.SpecificationId, doctor.SpecificationId)
                        .SetProperty(d => d.DistrictId, doctor.DistrictId));

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
                await context.Doctors
                    .Where(d => d.Id == id)
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