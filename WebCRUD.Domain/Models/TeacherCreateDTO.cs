using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD.Domain.Models
{
    public class TeacherCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int parol { get; set; }
        public IEnumerable<int> StudentIds { get; set; }
    }
}
