﻿using Application.Services;
using Microsoft.AspNetCore.Mvc;
using TestTaskSRC.Contracts.Create;
using TestTaskSRC.Contracts.Response;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<AppointmentResponse>> GetAppointmentById(Guid appointmentId)
        {
            var result = await appointmentService.GetAppointmentByIdAsync(appointmentId);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return new AppointmentResponse(
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
        public async Task<ActionResult> UpdateAppointment(Guid appointmentId, AppointmentCreate appointmentCreate)
        {
            var result = await appointmentService.UpdateAppointmentAsync(
                appointmentId,
                appointmentCreate.PatientId,
                appointmentCreate.DoctorId,
                appointmentCreate.DateTime);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAppointment(Guid appointmentId)
        {
            var result = await appointmentService.DeleteAppointmentAsync(appointmentId);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}
