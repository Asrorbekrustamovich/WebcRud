using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.Models;

namespace WebCRUD.Domain.validationforcreateteacher
{
    public class ValidateforTeacherCreate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var something = validationContext.ObjectInstance as TeacherCreateDTO;
            if(!something.Email.Contains("@gmail.com"))
            {
                return new ValidationResult("gmailni xato kiritdingiz");
            }
            return ValidationResult.Success;
        }
    }
}
