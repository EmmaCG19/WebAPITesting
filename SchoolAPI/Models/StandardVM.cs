using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolAPI.DAL;

namespace SchoolAPI.Models
{
    public class StandardVM
    {
        public StandardVM()
        {
            
        }

        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public IEnumerable<StudentVM> Students { get; set; }

    }
}