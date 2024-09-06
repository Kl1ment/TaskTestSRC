namespace DataAccess.Entities
{
    public class CabinetEntity
    {
        public Guid Id { get; set; }
        public int Number { get; set; }

        public List<DoctorEntity>? Doctors { get; set; }
    }
}
