namespace DataAccess.Entities
{
    public class PatientEntity
    {
        public Guid Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; } = string.Empty;
        public int? District { get; set; }

        public DistrictEntity? DistrictEntity { get; set; }
        public List<AppointmentEntity>? Appointments { get; set; }
    }
}
