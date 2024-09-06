using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DoctorRepository(SRCDbContext context) : IDoctorRepository
    {
        private const int PageSize = 2;

        public async Task<Result> AddAsync(Doctor doctor)
        {
            try
            {
                var doctorEntity = new DoctorEntity
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    Cabinet = doctor.Cabinet,
                    Specification = doctor.Specification,
                    District = doctor.District
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

        public async Task<List<Doctor>> GetAsync(DoctorSortField sortField, int page)
        {
            var query = context.Doctors
                .AsNoTracking()
                .Skip(page - 1)
                .Take(PageSize);

            switch (sortField)
            {
                case DoctorSortField.FullName: query = query.OrderBy(d => d.FullName); break;
                case DoctorSortField.Cabinet: query = query.OrderBy(d => d.Cabinet); break;
                case DoctorSortField.Specification: query = query.OrderBy(d => d.Specification); break;
                case DoctorSortField.District: query = query.OrderBy(d => d.District); break;
            }

            var doctorEntity = await query.ToListAsync();

            return doctorEntity.Select(d => Doctor.Response(
                d.Id,
                d.FullName,
                d.Cabinet,
                d.Specification,
                d.District)).ToList();
        }

        public async Task<Result<Doctor>> GetByIdAsync(Guid id)
        {
            var doctorEntity = await context.Doctors
                .AsNoTracking()
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();

            if (doctorEntity == null)
                return Result.Failure<Doctor>("The doctor was not found");

            return Doctor.Response(
                doctorEntity.Id,
                doctorEntity.FullName,
                doctorEntity.Cabinet,
                doctorEntity.Specification,
                doctorEntity.District);
        }

        public async Task<Result> UpdateAsync(Doctor doctor)
        {
            try
            {
                await context.Doctors
                    .Where(d => d.Id == doctor.Id)
                    .ExecuteUpdateAsync(p => p
                        .SetProperty(d => d.FullName, doctor.FullName)
                        .SetProperty(d => d.Cabinet, doctor.Cabinet)
                        .SetProperty(d => d.District, doctor.District));

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