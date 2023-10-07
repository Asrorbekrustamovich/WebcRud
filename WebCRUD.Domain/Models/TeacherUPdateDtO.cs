using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD.Domain.Models
{
    public  class TeacherUPdateDtO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public IEnumerable<int> studentids { get; set; }
    }
}
