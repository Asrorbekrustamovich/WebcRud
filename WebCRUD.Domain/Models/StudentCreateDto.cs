using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.ValidationforCreatesrudentDTo;

namespace WebCRUD.Domain.Models
{
    public class StudentCreateDto
    {
        public string Fullname { get; set; }
        [Validate]
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<int> teacherids { get; set; }    
    }
}
