using Core.Models.DTOs;

namespace Core.Models
{
    public class Doctor
    {
        public Guid Id { get; }
        public string FullName { get; }
        public Guid? CabinetId { get; }
        public Guid? SpecificationId { get; }
        public Guid? DistrictId { get; }

        private Doctor(Guid id, string fullName, Guid? cabinetId, Guid? specificationId, Guid? districtId)
        {
            Id = id;
            FullName = fullName;
            CabinetId = cabinetId;
            SpecificationId = specificationId;
            DistrictId = districtId;
        }

        public static Doctor Create(Guid id, string fullName, Guid? cabinetId, Guid? specificationId, Guid? districtId)
        {
            var validator = new Validator();

            if (!validator
                .IsNotEmpty(fullName, nameof(FullName))
                .IsValid)
                throw new ArgumentException(validator.Error);

            return new Doctor(id, fullName, cabinetId, specificationId, districtId);
        }
    }
}
