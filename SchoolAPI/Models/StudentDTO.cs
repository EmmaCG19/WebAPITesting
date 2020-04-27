using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.DAL;

namespace SchoolAPI.Models
{
    public class StudentDTO
    {
        public StudentDTO()
        {

        }

        public int Id { get; set; }
        public string FullName { get; set; }

        //Navigation properties
        public StandardDTO Standard { get; set; }
        public StudentAdressDTO Address { get; set; }
                

    }
}