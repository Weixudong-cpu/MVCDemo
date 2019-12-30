using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }
        public bool Sex { get; set; }

        public string Sname { get; set; }

        public string Sremark { get; set; }

        public int Pid { get; set; }
        public int Age { get; set; }
        public string Hobby { get; set; }
    }
}
