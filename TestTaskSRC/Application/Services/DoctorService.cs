using Core;
using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
    {
        public async Task<Result> AddDoctorAsync(
            string fullName,
            Guid cabinetId,
            Guid specificationId,
            Guid districtId)
        {
            var doctor = Doctor.Create(
                Guid.NewGuid(),
                fullName,
                cabinetId,
                specificationId,
                districtId);

            return await doctorRepository.AddAsync(doctor);
        }

        public async Task<List<DoctorDOT>> GetAllDoctorsAsync(string sortField, int page)
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

        public async Task<Result> UpdateDoctorAsync(
            Guid id,
            string fullName,
            Guid cabinetId,
            Guid specificationId,
            Guid districtId)
        {
            var doctor = Doctor.Create(
                id,
                fullName,
                cabinetId,
                specificationId,
                districtId);

            return await doctorRepository.UpdateAsync(doctor);
        }

        public async Task<Result> DeleteDoctorAsync(Guid id)
        {
            return await doctorRepository.DeleteAsync(id);
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
