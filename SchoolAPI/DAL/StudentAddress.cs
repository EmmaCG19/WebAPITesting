using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAPI.DAL
{
    public class StudentAddress
    {
        //StudentId is PK and FK(Student) by convention    

        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }

    }
}