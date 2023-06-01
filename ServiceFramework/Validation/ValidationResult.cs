namespace ServiceFramework.Validation
{
    public class ValidationResult
    {
        public string Message { get; protected set; }

        public ValidationResult()
        {

        }

        public ValidationResult(string message)
        {
            Message = message;

        }
    }
}