
using FluentValidation.Results;


namespace Cars.Domain.Exceptions
{
    public class ValidationExceptions:Exception
    {
        public ValidationExceptions(string message):base(message)
        {
            
        }
        public ValidationExceptions(string message, ValidationResult validationResult):base(message)
        {
            ValidationErrors = new List<string>(); 
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }
        public List<string> ValidationErrors { get; set; }
    }
}
