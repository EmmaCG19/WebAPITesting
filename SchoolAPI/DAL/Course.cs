using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAPI.DAL
{
    [Table("Grade")]
    public class Course
    {
        public int CourseId { get; set; }


        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
    }
}