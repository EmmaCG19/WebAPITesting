using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SchoolAPI.DAL
{
    //1..0|1
    public class Student: Person
    {
        public int StudentId { get; set; }
        public int StandardId { get; set; }

        public virtual Standard Standard{ get; set; }
        public virtual StudentAddress Address { get; set; }
    }
}