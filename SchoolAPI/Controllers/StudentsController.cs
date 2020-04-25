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

        public IHttpActionResult GetAllStudents(bool includeAddress = false)
        {
            List<StudentVM> students = null;

            using (var context = new SchoolDBEntities())
            {
                students = context.Students
                                        .Include("StudentAddress")
                                        .Select(s => new StudentVM()
                                        {
                                            Id = s.StudentID,
                                            FullName = s.StudentName,
                                            Address = s.StudentAddress == null || includeAddress == false ? null : new StudentAdressVM()
                                            {
                                                StudentId = s.StudentID,
                                                Address1 = s.StudentAddress.Address1,
                                                Address2 = s.StudentAddress.Address2,
                                                State = s.StudentAddress.State,
                                                City = s.StudentAddress.City
                                            }
                                        })
                                        .ToList<StudentVM>();

            }

            if (students.Count == 0)
                return NotFound();

            return Ok(students);
        }


        public IHttpActionResult GetStudentById(int id)
        {
            StudentVM student = null;

            using (var context = new SchoolDBEntities())
            {
                student = context.Students
                                   .Where(s => s.StudentID == id)
                                   .Select(s => new StudentVM()
                                   {
                                       Id = s.StudentID,
                                       FullName = s.StudentName

                                   }).FirstOrDefault<StudentVM>();
            }

            if (student is null)
                return NotFound();

            return Ok(student);
        }

        public IHttpActionResult PostStudent(StudentVM student)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var context = new SchoolDBEntities())
            {
                context.Students.Add(new Student()
                {
                    StudentName = student.FullName
                });

                context.SaveChanges();
            }

            return Ok(new StringContent(String.Format("El alumno se generó con el id {0}", student.Id)));

        }
    }
}
