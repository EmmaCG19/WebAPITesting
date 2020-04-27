using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCSchool.Models
{
    public class StudentVM
    {
        [Required]
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<StudentVM> Students { get; set; }
    }
}