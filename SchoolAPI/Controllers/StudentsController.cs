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

        [HttpGet]
        [Route("api/students/{name:alpha}")]
        public IHttpActionResult GetStudentsByName(string name, bool addressIncluded = false)
        {
            IList<StudentVM> studentsByName = null;

            using (var context = new SchoolDBEntities())
            {
                studentsByName = context.Students
                    .Include("StudentAddress")
                    .Where(s => s.StudentName.ToLower().Equals(name.ToLower()))
                    .Select(s => new StudentVM()
                    {
                        Id = s.StudentID,
                        FullName = s.StudentName,
                        Address = s.StudentAddress == null || addressIncluded == false ? null :
                        new StudentAdressVM()
                        {
                            StudentId = s.StudentID,
                            City = s.StudentAddress.City,
                            State = s.StudentAddress.State,
                            Address1 = s.StudentAddress.Address1,
                            Address2 = s.StudentAddress.Address2

                        }
                    })
                    .ToList<StudentVM>();
            }

            if (studentsByName.Count == 0)
                return NotFound();

            return Ok(studentsByName);
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
                    StudentID = student.Id,
                    StudentName = student.FullName,
                    StandardId = 3
                });

                context.SaveChanges();
            }


            //Devolver el estudiante con el id generado
            return Ok();

        }

        public IHttpActionResult PutStudent(StudentVM student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Los datos ingresados son inválidos.");

            using (var context = new SchoolDBEntities())
            {
                var estExistente = context.Students
                                .Where(s => s.StudentID == student.Id)
                                .FirstOrDefault<Student>();

                if (estExistente != null)
                {
                    estExistente.StudentName = student.FullName;
                    context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

            }

            return Ok();
        }


        public IHttpActionResult DeleteStudent(int id)
        {
            if (id < 0)
                return BadRequest("El id es inválido.");

            using (var context = new SchoolDBEntities())
            {
                var student = context.Students.Where(s => s.StudentID == id).FirstOrDefault<Student>();

                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
                else
                    return NotFound();

                return Ok();
            }

        }
    }
}
