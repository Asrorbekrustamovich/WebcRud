using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.Models;

namespace WebCRUD.Domain.Fluentvalidation
{
    public class FluentstudentCreate:AbstractValidator<StudentCreateDto>
    {
        public FluentstudentCreate()
        {
            RuleFor(x => x.Fullname).Must(Uppercase).WithMessage("birinchi harf katta harf bilan yozilishi kerak");
            RuleFor(x => x.Password).Password();
        }
        private static bool Uppercase(string name)
        {
            if (char.IsUpper(name[0]))
            {
                return true;
            }
            return false;
        }
    }
}
