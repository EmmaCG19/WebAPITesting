using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolAPI.DAL;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    public class StudentsController : ApiController
    {
        public IHttpActionResult GetAllStudents()
        {
            List<StudentDTO> students = new List<StudentDTO>();
            using (SchoolDBContext context = new SchoolDBContext())
            {
                try
                {
                    students = context.Students
                                            .Include("Standard")
                                            .Select(s =>
                                            new StudentDTO()
                                            {
                                                Id = s.StudentId,
                                                FullName = s.Name + " " + s.Surname,
                                                Standard = new StandardDTO()
                                                {
                                                    StandardId = s.Standard.StandardId,
                                                    Name = s.Standard.Name
                                                }
                                            })
                                            .ToList();
                }
                catch (HttpResponseException e)
                {
                    e.Response.Content = new StringContent(e.InnerException.Message);
                    e.Response.ReasonPhrase = "Clases de dominio mal definidas";

                    return Ok(e);
                }

            }

            if (students.Count == 0)
                return NotFound();

            return Ok(students);
        }

    }
}
