using Core;
using Core.Models;
using Core.Models.DTOs;
using CSharpFunctionalExtensions;
using DataAccess.Repositories;

namespace Application.Services
{
    public class PatientService(IPatientRepository patientRepository) : IPatientService
    {
        public async Task<Result> AddPatientAsync(
            string surname,
            string name,
            string patronymic,
            string address,
            DateTime birthDate,
            string sex,
            Guid districtId)
        {
            var patient = Patient.Create(
                Guid.NewGuid(),
                surname,
                name,
                patronymic,
                address,
                birthDate,
                sex,
                districtId);

            return await patientRepository.AddAsync(patient);
        }

        public async Task<List<PatientDTO>> GetAllPatientsAsync(string sortField, int page)
        {
            var validator = new Validator();

            if (!validator.IsPositive(page - 1, nameof(page)).IsValid)
                throw new ArgumentException(validator.Error);

            var patientSortField = DefineSortField(sortField);

            return await patientRepository.GetAsync(patientSortField, page);
        }

        public async Task<Result<Patient>> GetPatientByIdAsync(Guid id)
        {
            return await patientRepository.GetByIdAsync(id);
        }

        public async Task<Result> UpdatePatientAsync(
            Guid id,
            string surname,
            string name,
            string patronymic,
            string address,
            DateTime birthDate,
            string sex,
            Guid districtId)
        {
            var patient = Patient.Create(
                id,
                surname,
                name,
                patronymic,
                address,
                birthDate,
                sex,
                districtId);

            return await patientRepository.UpdateAsync(patient);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            return await patientRepository.DeleteAsync(id);
        }

        private PatientSortField DefineSortField(string sortField)
        {
            switch (sortField.ToLower())
            {
                case "name": return PatientSortField.Name;
                case "patronymic": return PatientSortField.Patronymic;
                case "address": return PatientSortField.Address;
                case "birthdate": return PatientSortField.BirthDate;
                case "sex": return PatientSortField.Sex;
                case "district": return PatientSortField.District;
                default: return PatientSortField.Surname;
            }
        }
    }
}
