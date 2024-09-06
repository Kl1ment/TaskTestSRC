namespace Core
{
    public class Validator
    {
        public bool IsValid => _isValid;
        public string Error => _error;

        private bool _isValid = true;
        private string _error = string.Empty;

        public Validator IsNotEmpty(string value, string fieldName)
        {
            return Validate(
                value != null && value != string.Empty,
                $"{fieldName} cannot be empty\n");
        }

        public Validator IsPositive(int value, string fieldName)
        {
            return Validate(
                value >= 0,
                $"{fieldName} cannot be lees than 0\n");
        }

        public Validator IsEarlyCurrentDate(DateTime value, string fieldName)
        {
            return Validate(
                value < DateTime.Now,
                $"{fieldName} cannot be later than the current date\n");
        }

        public Validator IsLaterCurrentDate(DateTime value, string fieldName)
        {
            return Validate(
                value >= DateTime.Now,
                $"{fieldName} cannot be early than the current date\n");
        }

        private Validator Validate(bool expression, string error)
        {
            if (!expression)
            {
                _isValid = false;
                _error += error;
            }

            return this;
        }
    }
}
