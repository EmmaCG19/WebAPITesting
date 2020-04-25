using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.DAL;

namespace SchoolAPI.Models
{
    public class StudentVM
    {
        public StudentVM()
        {

        }

        public int Id { get; set; }
        public string FullName { get; set; }

        //Navigation properties
        public StandardVM Standard { get; set; }
        public StudentAdressVM Address { get; set; }
                

    }
}