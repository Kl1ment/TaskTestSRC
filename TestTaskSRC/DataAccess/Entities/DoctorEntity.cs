namespace DataAccess.Entities
{
    public class DoctorEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public Guid? CabinetId { get; set; }
        public Guid? SpecificationId { get; set; }
        public Guid? DistrictId { get; set; }

        public DistrictEntity? DistrictEntity { get; set; }
        public CabinetEntity? CabinetEntity { get; set; }
        public SpecificationEntity? SpecificationEntity { get; set; }
        public List<AppointmentEntity>? Appointments { get; set; }
    }
}
