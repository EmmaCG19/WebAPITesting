using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSchool.Models;
using System.Net.Http;

namespace MVCSchool.Controllers
{
    public class StudentsController : Controller
    {
        [ActionName("all")]
        public ActionResult GetAllStudents()
        {
            StudentVM model = new StudentVM();
            using (var cliente = new HttpClient())
            {
                //Debemos obtener todos los estudiantes y mostrarlos en una lista
                cliente.BaseAddress = new Uri("http://localhost:50022/api/");
                var request = cliente.GetAsync("students");
                request.Wait();

                var response = request.Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<List<StudentVM>>();
                    result.Wait();

                    model.Students = result.Result;
                }
            }

            ViewBag.Title = "GetAllStudents";

            return View(model);
        }

        [ActionName("byId")]
        public ActionResult GetStudentById(int id=1)
        {
            StudentVM model = new StudentVM();

            //Id invalido
            if (id <= 0)
            {
                ViewBag.Error = "El id no es válido";
                return View();
            }

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:50022/api/");

                //Generar el request
                //var request = cliente.GetAsync("students/1");
                var request = cliente.GetAsync("students/"+ id);
                request.Wait();

                //Obtener la response
                var response = request.Result;

                if (response.IsSuccessStatusCode)
                {
                    //Leer el dato obtenido
                    var result = response.Content.ReadAsAsync<StudentVM>();
                    result.Wait();

                    model = result.Result;
                }
                else
                {
                    ViewBag.Error = "El estudiante con ese id no existe.";
                }
            }

            ViewBag.Title = "GetStudentById";

            return View(model);
        }
    }
}