namespace Core.Models
{
    public class AppointmentCreator
    {
        public Guid Id { get; }
        public Guid PatientId { get; }
        public Guid DoctorId { get; }
        public DateTime DateTime { get; }

        private AppointmentCreator(Guid id, Guid patientId, Guid doctorId, DateTime dateTime)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            DateTime = dateTime;
        }

        public static AppointmentCreator Create(Guid id, Guid patientId, Guid doctorId, DateTime dateTime)
        {
            var validator = new Validator();

            if (!validator.IsLaterCurrentDate(dateTime, nameof(DateTime)).IsValid)
                throw new InvalidOperationException(validator.Error);

            return new AppointmentCreator(id, patientId, doctorId, dateTime);
        }
    }
}
