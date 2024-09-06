namespace TestTaskSRC.Contracts.Response
{
    public record AppointmentResponse(
        Guid Id,
        string PatientSurname,
        string PatientName,
        string PatientPatronymic,
        string DoctorFullName,
        string DoctorSpecification,
        DateTime DateTime,
        int Cabinet);
}
