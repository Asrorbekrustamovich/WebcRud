﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD.Domain.Models
{
    public class StudentCreateDto
    {
        public string Fullname { get; set; }
        public IEnumerable<int> teacherids { get; set; }    
    }
}
