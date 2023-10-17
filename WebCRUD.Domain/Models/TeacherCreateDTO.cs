using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.validationforcreateteacher;

namespace WebCRUD.Domain.Models
{
    public class TeacherCreateDTO
    {
        public string Name { get; set; }
        [ValidateforTeacherCreate]
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<int> StudentIds { get; set; }
    }
}
