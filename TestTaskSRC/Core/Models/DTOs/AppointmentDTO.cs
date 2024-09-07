namespace Core.Models.DTOs
{
    public class AppointmentDTO(
        Guid id,
        string patientSurname,
        string patientName,
        string patientPatronymic,
        string doctorFullName,
        string? specification,
        DateTime dateTime,
        int? cabinet)
    {
        public Guid Id { get; } = id;
        public string PatientSurname { get; } = patientSurname;
        public string PatientName { get; } = patientName;
        public string PatientPatronymic { get; } = patientPatronymic;
        public string DoctorFullName { get; } = doctorFullName;
        public string? Specification { get; } = specification;
        public DateTime DateTime { get; } = dateTime;
        public int? Cabinet { get; } = cabinet;
    }
}
