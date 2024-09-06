namespace DataAccess.Entities
{
    public class AppointmentEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime DateTime { get; set; }

        public PatientEntity PatientEntity { get; set; } = null!;
        public DoctorEntity DoctorEntity { get; set; } = null!;
    }
}
