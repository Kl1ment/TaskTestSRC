namespace TestTaskSRC.Contracts.Response
{
    public record AppointmentResponse(
        Guid Id,
        Guid? PatientId,
        Guid DoctorId,
        DateTime DateTime);
}
