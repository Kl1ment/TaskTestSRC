﻿namespace Core.Models
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
        public Guid? DistrictId { get; }

        private Patient(Guid id, string surname, string name, string patronymic, string address, DateTime birthdate, string sex, Guid? districtId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Address = address;
            Birthdate = birthdate;
            Sex = sex;
            DistrictId = districtId;
        }

        public static Patient Create(Guid id, string surname, string name, string patronymic, string address, DateTime birthdate, string sex, Guid? districtId)
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

            return new Patient(id, surname, name, patronymic, address, birthdate, sex, districtId);
        }
    }
}
