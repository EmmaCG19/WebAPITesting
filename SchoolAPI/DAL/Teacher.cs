using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.DAL
{
    public class Teacher:Person
    {
        public int TeacherId { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }

    }
}