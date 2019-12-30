using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class Mxmx
    {
        [Key]
        public int Sid { get; set; }

        public string Sname { get; set; }

        public string Sremark { get; set; }
    }
}
