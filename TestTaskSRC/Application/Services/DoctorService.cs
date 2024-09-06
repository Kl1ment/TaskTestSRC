using Core;
using Core.Models;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
    {
        public async Task<Result> AddDoctorAsync(
            string fullName,
            int cabinet,
            string specification,
            int district)
        {
            var doctor = Doctor.Create(
                Guid.NewGuid(),
                fullName,
                cabinet,
                specification,
                district);

            return await doctorRepository.AddAsync(doctor);
        }

        public async Task<Result> UpdateDoctorAsync(
            Guid id,
            string fullName,
            int cabinet,
            string specification,
            int district)
        {
            var doctor = Doctor.Create(
                id,
                fullName,
                cabinet,
                specification,
                district);

            return await doctorRepository.UpdateAsync(doctor);
        }

        public async Task<Result> DeleteDoctorAsync(Guid id)
        {
            return await doctorRepository.DeleteAsync(id);
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync(string sortField, int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            var doctorSortField = DefineSortField(sortField);

            return await doctorRepository.GetAsync(doctorSortField, page);
        }

        public async Task<Result<Doctor>> GetByIdAsync(Guid id)
        {
           return await doctorRepository.GetByIdAsync(id);
        }

        private DoctorSortField DefineSortField(string sortField)
        {
            switch (sortField.ToLower())
            {
                case "cabinet": return DoctorSortField.Cabinet;
                case "specification": return DoctorSortField.Specification;
                case "district": return DoctorSortField.District;
                default: return DoctorSortField.FullName;
            }
        }
    }
}
