using Microsoft.AspNetCore.Identity;

namespace Megasave.Application.Exceptions
{
    public class IdentityException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }

        public IdentityException(IEnumerable<IdentityError> validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var validationError in validationResult)
            {
                ValidationErrors.Add(validationError.Description);
            }
        }
    }
}