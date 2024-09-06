namespace Core.Models
{
    public class Specification
    {
        public Guid Id { get; }
        public string Name { get; }

        private Specification(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Specification Create(Guid id, string name)
        {
            var validator = new Validator();

            if (!validator.IsNotEmpty(name, nameof(name)).IsValid)
                throw new ArgumentException(validator.Error);

            return new Specification(id, name);
        }
    }
}
