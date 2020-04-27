using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.DAL;

namespace SchoolAPI.Models
{
    public class StandardDTO
    {
        public StandardDTO()
        {
            
        }

        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }

    }
}