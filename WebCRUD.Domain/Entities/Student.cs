using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.Models;

namespace WebCRUD.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public ICollection<Teacher?>Teachers { get; set; }
    }
}
