using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.Models;

namespace WebCRUD.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FUllname { get; set; }
        public List<Teacher>?Teachers { get; set; }
    }
}
