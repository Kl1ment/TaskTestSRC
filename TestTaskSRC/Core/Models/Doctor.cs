namespace Core.Models
{
    public class Doctor
    {
        public Guid Id { get; }
        public string FullName { get; }
        public int? Cabinet { get; }
        public string? Specification { get; }
        public int? District { get; }

        private Doctor(Guid id, string fullName, int? cabinet, string? specification, int? district)
        {
            Id = id;
            FullName = fullName;
            Cabinet = cabinet;
            Specification = specification;
            District = district;
        }

        public static Doctor Create(Guid id, string fullName, int cabinet, string specification, int district)
        {
            var validator = new Validator();

            if (!validator
                .IsNotEmpty(fullName, nameof(FullName))
                .IsPositive(cabinet, nameof(Cabinet))
                .IsNotEmpty(specification, nameof(Specification))
                .IsPositive(district, nameof(District))
                .IsValid)
                throw new ArgumentException(validator.Error);

            return new Doctor(id, fullName, cabinet, specification, district);
        }

        public static Doctor Response(Guid id, string fullName, int? cabinet, string? specification, int? district)
        {
            return new Doctor(id, fullName, cabinet, specification, district);
        }
    }
}
