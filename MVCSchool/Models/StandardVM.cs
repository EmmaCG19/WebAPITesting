using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSchool.Models
{
    public class StandardVM
    {
        public StandardVM()
        {

        }

        public int StandardId { get; set; }
        public List<StudentVM> Students { get; set; }
    }
}