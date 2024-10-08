﻿using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController(
        IPatientService patientService,
        IAppointmentService appointmentService) : ControllerBase
    {
        [HttpGet("All")]
        public async Task<ActionResult<List<PatientDTOResponse>>> GetAllPatients(string sortField, int page)
        {
            var patients = await patientService.GetAllPatientsAsync(sortField, page);

            return patients.Select(p => new PatientDTOResponse(
                p.Id,
                p.Surname,
                p.Name,
                p.Patronymic,
                p.Address,
                p.Birthdate,
                p.Sex,
                p.District)).ToList();
        }

        [HttpGet]
        public async Task<ActionResult<PatientResponse>> GetPatientById(Guid patientId)
        {
            var result = await patientService.GetPatientByIdAsync(patientId);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return new PatientResponse(
                result.Value.Id,
                result.Value.Surname,
                result.Value.Name,
                result.Value.Patronymic,
                result.Value.Address,
                result.Value.Birthdate,
                result.Value.Sex,
                result.Value.DistrictId);
        }

        [HttpGet("Appointments")]
        public async Task<List<AppointmentDTOResponse>> GetAppointmentsByPatientId(Guid patientId, int page)
        {
            var appointments = await appointmentService.GetPatientAppointmentsAsync(patientId, page);

            return appointments.Select(a => new AppointmentDTOResponse(
                a.Id,
                a.PatientSurname,
                a.PatientName,
                a.PatientPatronymic,
                a.DoctorFullName,
                a.Specification,
                a.DateTime,
                a.Cabinet)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient(PatientCreate patientCreate)
        {
            var result = await patientService.AddPatientAsync(
                patientCreate.Surname,
                patientCreate.Name,
                patientCreate.Patronymic,
                patientCreate.Address,
                patientCreate.Birthdate,
                patientCreate.Sex,
                patientCreate.DistrictId);

            if (result.IsFailure)
                return BadRequest(result);

            return RedirectToAction(nameof(GetAllPatients), new { sortField = "Surname", page = 1 });
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePatient(Guid patientId, PatientCreate patientCreate)
        {
            var result = await patientService.UpdatePatientAsync(
                patientId,
                patientCreate.Surname,
                patientCreate.Name,
                patientCreate.Patronymic,
                patientCreate.Address,
                patientCreate.Birthdate,
                patientCreate.Sex,
                patientCreate.DistrictId);

            if (result.IsFailure)
                return BadRequest(result);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePatient(Guid patientId)
        {
            var result = await patientService.DeleteAsync(patientId);

            if (result.IsFailure)
                return BadRequest(result);

            return Ok();
        }
    }
}
