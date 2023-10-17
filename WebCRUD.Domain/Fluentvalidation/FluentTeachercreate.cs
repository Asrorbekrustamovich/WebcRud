using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.Models;

namespace WebCRUD.Domain.Fluentvalidation
{
    public class FluentTeachercreate:AbstractValidator<TeacherCreateDTO>
    {
        public FluentTeachercreate()
        {
            RuleFor(x => x.Name).Must(Uppercase).WithMessage("birinchi harf katta harf bilan yozilishi kerak");
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
