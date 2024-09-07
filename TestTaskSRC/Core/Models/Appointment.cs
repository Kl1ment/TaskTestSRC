namespace Core.Models
{
    public class Appointment
    {
        public Guid Id { get; }
        public Guid PatientId { get; }
        public Guid DoctorId { get; }
        public DateTime DateTime { get; }

        private Appointment(Guid id, Guid patientId, Guid doctorId, DateTime dateTime)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            DateTime = dateTime;
        }

        public static Appointment Create(Guid id, Guid patientId, Guid doctorId, DateTime dateTime)
        {
            var validator = new Validator();

            if (!validator.IsLaterCurrentDate(dateTime, nameof(DateTime)).IsValid)
                throw new InvalidOperationException(validator.Error);

            return new Appointment(id, patientId, doctorId, dateTime);
        }
    }
}
