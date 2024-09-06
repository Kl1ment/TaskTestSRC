using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    internal class PatientRepository(SRCDbContext context) : IPatientRepository
    {
        private const int PageSize = 2;

        public async Task<Result> AddAsync(Patient patient)
        {
            try
            {
                var patientEntity = new PatientEntity
                {
                    Id = patient.Id,
                    Surname = patient.Surname,
                    Name = patient.Name,
                    Patronymic = patient.Patronymic,
                    Address = patient.Address,
                    Birthdate = patient.Birthdate,
                    Sex = patient.Sex,
                    District = patient.District
                };

                await context.Patients.AddAsync(patientEntity);
                await context.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<List<Patient>> GetAsync(PatientSortField sortField, int page)
        {
            var query = context.Patients
                .AsNoTracking()
                .Skip(page - 1)
                .Take(PageSize);

            switch (sortField)
            {
                case PatientSortField.Surname: query = query.OrderBy(x => x.Surname); break;
                case PatientSortField.Name: query = query.OrderBy(x => x.Name); break;
                case PatientSortField.Patronymic: query = query.OrderBy(x => x.Patronymic); break;
                case PatientSortField.Address: query = query.OrderBy(x => x.Address); break;
                case PatientSortField.BirthDate: query = query.OrderBy(x => x.Birthdate); break;
                case PatientSortField.Sex: query = query.OrderBy(x => x.Sex); break;
                case PatientSortField.District: query = query.OrderBy(x => x.District); break;
            }

            var patientEntities = await query.ToListAsync();

            return patientEntities.Select(p => Patient.Response(
                p.Id,
                p.Surname,
                p.Name,
                p.Patronymic,
                p.Address,
                p.Birthdate,
                p.Sex,
                p.District)).ToList();
        }

        public async Task<Result<Patient>> GetByIdAsync(Guid id)
        {
            var patientEntity = await context.Patients
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (patientEntity == null)
                return Result.Failure<Patient>("The patient was not found");

            return Patient.Response(
                patientEntity.Id,
                patientEntity.Surname,
                patientEntity.Name,
                patientEntity.Patronymic,
                patientEntity.Address,
                patientEntity.Birthdate,
                patientEntity.Sex,
                patientEntity.District);
        }

        public async Task<Result> UpdateAsync(Patient patient)
        {
            try
            {
                await context.Patients
                    .Where(d => d.Id == patient.Id)
                    .ExecuteUpdateAsync(p => p
                        .SetProperty(p => p.Surname, patient.Surname)
                        .SetProperty(p => p.Name, patient.Name)
                        .SetProperty(p => p.Patronymic, patient.Patronymic)
                        .SetProperty(p => p.Address, patient.Address)
                        .SetProperty(p => p.Sex, patient.Sex)
                        .SetProperty(p => p.District, patient.District));

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
                await context.Patients
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
