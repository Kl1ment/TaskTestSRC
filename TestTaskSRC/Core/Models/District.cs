namespace Core.Models
{
    public class District
    {
        public Guid Id { get; }
        public int Number { get; }

        private District(Guid id, int number)
        {
            Id = id;
            Number = number;
        }

        public static District Create(Guid id, int number)
        {
            var validator = new Validator();

            if (!validator.IsPositive(number, nameof(Number)).IsValid)
                throw new ArgumentException(validator.Error);

            return new District(id, number);
        }
    }
}
