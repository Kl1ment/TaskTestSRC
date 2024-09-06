using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Request;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<AppointmentForUpdateResponse>> GetAppointmentById(
            AppointmentRequest appointmentRequest)
        {
            var result = await appointmentService.GetAppointmentByIdAsync(
                appointmentRequest.Id);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return new AppointmentForUpdateResponse(
                result.Value.Id,
                result.Value.PatientId,
                result.Value.DoctorId,
                result.Value.DateTime);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppointment(AppointmentCreate appointmentCreate)
        {
            var result = await appointmentService.AddAppointmentAsync(
                appointmentCreate.PatientId,
                appointmentCreate.DoctorId,
                appointmentCreate.DateTime);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAppointment(AppointmentCreate appointmentCreate)
        {
            var result = await appointmentService.AddAppointmentAsync(
                appointmentCreate.PatientId,
                appointmentCreate.DoctorId,
                appointmentCreate.DateTime);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAppointment(AppointmentRequest appointment)
        {
            var result = await appointmentService.DeleteAppointmentAsync(
                appointment.Id);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
