namespace Core.Models
{
    public class Cabinet
    {
        public Guid Id { get; }
        public int Number { get; }

        private Cabinet(Guid id, int number)
        {
            Id = id;
            Number = number;
        }

        public static Cabinet Create(Guid id, int number)
        {
            var validator = new Validator();

            if (!validator.IsPositive(number, nameof(Number)).IsValid)
                throw new ArgumentException(validator.Error);

            return new Cabinet(id, number);
        }

        public static Cabinet Response(Guid id, int number)
        {
            return new Cabinet(id, number);
        }
    }
}
