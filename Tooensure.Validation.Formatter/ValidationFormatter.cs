namespace Tooensure.Validation.Formatter
{
    public class ValidationFormatter
    {
        private Dictionary<string, bool> Validations { get; set; } = new Dictionary<string, bool>();

        public ValidationFormatter AddValidation(string message, bool condition)
        {
            Validations.Add(message, condition);
            return this;
        }

        public bool Validate()
        {

            foreach (var validation in Validations)
            {
                if (validation.Value.Equals(true)) return false;
            }
            return true;
        }

        public string GetFaildValidation()
        {
            //1. Initualize empty string
            var log = string.Empty;

            //2. forch each true validation append string
            foreach (var validation in Validations)
            {
                if (validation.Value.Equals(true)) log += $"[{validation.Key}], "; Validations.Remove(validation.Key);
            }
            return log;
        }
    }
}