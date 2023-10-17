using System.ComponentModel.DataAnnotations;
using WebCRUD.Domain.Models;

namespace WebCRUD.Domain.ValidationforCreatesrudentDTo
{
    public class ValidateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var someting = validationContext.ObjectInstance as StudentCreateDto;
            if(!someting.Email.Contains("@gmail.com"))
            {
                return new ValidationResult("error");
            }
            return ValidationResult.Success;
        }
    }
}
