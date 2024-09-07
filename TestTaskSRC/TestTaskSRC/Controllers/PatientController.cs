using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController(IPatientService patientService) : ControllerBase
    {
        [HttpGet]
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

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<PatientResponse>> GetPatientById(Guid id)
        {
            var result = await patientService.GetPatientByIdAsync(id);

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

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePatient(Guid id, PatientCreate patientCreate)
        {
            var result = await patientService.UpdatePatientAsync(
                id,
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
        public async Task<ActionResult> DeletePatient(Guid id)
        {
            var result = await patientService.DeleteAsync(id);

            if (result.IsFailure)
                return BadRequest(result);

            return Ok();
        }
    }
}
