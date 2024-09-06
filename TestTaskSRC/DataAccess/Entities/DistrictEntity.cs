namespace DataAccess.Entities
{
    public class DistrictEntity
    {
        public Guid Id { get; set; }
        public int Number { get; set; }

        public List<DoctorEntity>? Doctors { get; set; }
        public List<PatientEntity>? Patients { get; set; }
    }
}
