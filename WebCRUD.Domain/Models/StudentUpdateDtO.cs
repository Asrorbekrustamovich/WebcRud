using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD.Domain.Models
{
    public class StudentUpdateDtO
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<int> teacherids { get; set; }
    }
}
