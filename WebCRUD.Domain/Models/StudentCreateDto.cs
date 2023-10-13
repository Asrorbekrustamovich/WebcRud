using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD.Domain.Models
{
    public class StudentCreateDto : IValidatableObject
    {
        [MaxLength(20),MinLength(5)]
        public string? Fullname { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        [Range(0,100)]
        public IEnumerable<int> teacherids { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!Fullname.Contains("Az"))
            {
                yield return new ValidationResult("Not allowed");
            }
        }
    }
}
