namespace Core.Models.DTOs
{
    public class PatientDTO
    {
        public Guid Id { get; }
        public string Surname { get; }
        public string Name { get; }
        public string Patronymic { get; }
        public string Address { get; }
        public DateTime Birthdate { get; }
        public string Sex { get; }
        public int? District { get; }

        private PatientDTO(Guid id, string surname, string name, string patronymic, string address, DateTime birthdate, string sex, int? district)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Address = address;
            Birthdate = birthdate;
            Sex = sex;
            District = district;
        }

        public static PatientDTO Create(Guid id, string surname, string name, string patronymic, string address, DateTime birthdate, string sex, int? district)
        {
            var validator = new Validator();

            if (!validator
                .IsNotEmpty(surname, nameof(Surname))
                .IsNotEmpty(name, nameof(Name))
                .IsNotEmpty(patronymic, nameof(Patronymic))
                .IsNotEmpty(address, nameof(Address))
                .IsEarlyCurrentDate(birthdate, nameof(Birthdate))
                .IsNotEmpty(sex, nameof(Sex))
                .IsValid)
                throw new ArgumentException(validator.Error);

            return new PatientDTO(id, surname, name, patronymic, address, birthdate, sex, district);
        }
    }
}
