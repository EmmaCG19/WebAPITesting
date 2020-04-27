using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SchoolAPI.DAL
{
    public class Student
    {
        [Key, Required]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }

        public virtual StudentAddress Address { get; set; }
        public virtual Standard Standard { get; set; }

    }
}