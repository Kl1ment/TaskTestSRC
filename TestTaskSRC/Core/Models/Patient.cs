namespace Core.Models
{
    public class Patient
    {
        public Guid Id { get; }
        public string Surname { get; }
        public string Name { get; }
        public string Patronymic { get; }
        public string Address { get; }
        public DateTime Birthdate { get; }
        public string Sex { get; }
        public int? District { get; }

        private Patient(Guid id, string surname, string name, string patronymic, string address, DateTime birthdate, string sex, int? district)
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

        public static Patient Create(Guid id, string surname, string name, string patronymic, string address, DateTime birthdate, string sex, int district)
        {
            var validator = new Validator();

            if (!validator
                .IsNotEmpty(surname, nameof(Surname))
                .IsNotEmpty(name, nameof(Name))
                .IsNotEmpty(patronymic, nameof(Patronymic))
                .IsNotEmpty(address, nameof(Address))
                .IsEarlyCurrentDate(birthdate, nameof(Birthdate))
                .IsNotEmpty(sex, nameof(Sex))
                .IsPositive(district, nameof(District))
                .IsValid)
                throw new ArgumentException(validator.Error);

            return new Patient(id, surname, name, patronymic, address, birthdate, sex, district);
        }

        public static Patient Response(Guid id, string surname, string name, string patronymic, string address, DateTime birthdate, string sex, int? district)
        {
            return new Patient(id, surname, name, patronymic, address, birthdate, sex, district);
        }
    }
}
