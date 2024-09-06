namespace TestTaskSRC.Contracts.Create
{
    public record AppointmentCreate(
        Guid PatientId,
        Guid DoctorId,
        DateTime DateTime);
}
