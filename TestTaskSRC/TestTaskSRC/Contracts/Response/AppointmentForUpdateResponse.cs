namespace TestTaskSRC.Contracts.Response
{
    public record AppointmentForUpdateResponse(
        Guid Id,
        Guid? PatientId,
        Guid DoctorId,
        DateTime DateTime);
}
