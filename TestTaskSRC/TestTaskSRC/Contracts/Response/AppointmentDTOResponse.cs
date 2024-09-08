namespace TestTaskSRC.Contracts.Response
{
    public record AppointmentDTOResponse(
        Guid Id,
        string PatientSurname,
        string PatientName,
        string PatientPatronymic,
        string DoctorFullName,
        string? DoctorSpecification,
        DateTime DateTime,
        int? Cabinet);
}
