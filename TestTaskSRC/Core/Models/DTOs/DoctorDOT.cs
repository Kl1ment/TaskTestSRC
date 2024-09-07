namespace Core.Models.DTOs
{
    public class DoctorDOT
    {
        public Guid Id { get; }
        public string FullName { get; }
        public int? Cabinet { get; }
        public string? Specification { get; }
        public int? District { get; }

        private DoctorDOT(Guid id, string fullName, int? cabinet, string? specification, int? district)
        {
            Id = id;
            FullName = fullName;
            Cabinet = cabinet;
            Specification = specification;
            District = district;
        }

        public static DoctorDOT Create(Guid id, string fullName, int? cabinet, string? specification, int? district)
        {
            var validator = new Validator();

            if (!validator
                .IsNotEmpty(fullName, nameof(FullName))
                .IsValid)
                throw new ArgumentException(validator.Error);

            return new DoctorDOT(id, fullName, cabinet, specification, district);
        }
    }
}
