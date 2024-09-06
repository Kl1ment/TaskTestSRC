using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController(IDoctorService doctorService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<DoctorResponse>>> GetAllDoctors(string sortField, int page)
        {
            var doctors = await doctorService.GetAllDoctorsAsync(
                sortField, page);

            return doctors.Select(d => new DoctorResponse(
                d.Id,
                d.FullName,
                d.Cabinet,
                d.Specification,
                d.District)).ToList();
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<DoctorResponse>> GetDoctorById(Guid id)
        {
            var result = await doctorService.GetByIdAsync(id);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return new DoctorResponse(
                result.Value.Id,
                result.Value.FullName,
                result.Value.Cabinet,
                result.Value.Specification,
                result.Value.District);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor(DoctorCreate doctorCreate)
        {
            var result = await doctorService.AddDoctorAsync(
                doctorCreate.FullName,
                doctorCreate.Cabinet,
                doctorCreate.Specification,
                doctorCreate.District);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(Guid id, DoctorCreate doctorCreate)
        {
            var result = await doctorService.UpdateDoctorAsync(
                id,
                doctorCreate.FullName,
                doctorCreate.Cabinet,
                doctorCreate.Specification,
                doctorCreate.District);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDoctor(Guid id)
        {
            var result = await doctorService.DeleteDoctorAsync(id);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
